using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LB.Execl;
using MS.Cloud.Core.DependencyInjection;
using LB.Execl.Extensions;
using MS.Cloud.AspNetCore.Extensions;
using MS.Cloud.Swagger.Extensions;
using FluentValidation.AspNetCore;
using MS.Cloud.AspNetCore.Models;
using MS.Cloud.SqlSugarCore.Extensions;
using System.Reflection;
using static MS.Cloud.AspNetCore.Converters.SystemTextJsonConverter;
using MS.Cloud.AspNetCore.Middleware.Error;

namespace LB.API
{
    public class Startup
    {
        //oy2jjb5ffzwygz4ftbzqvqvnekc5zbau7mcrjf4uuuznzi consul keys
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.Converters.Add(new MS.Cloud.AspNetCore.Converters.SystemTextJsonConverter.DateTimeConverter());
                            options.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
                        })
                        .AddFluentValidation(options =>
                        {
                            var validatorList = GetFluentValidationValidator("LB.Appliation");
                            foreach (var item in validatorList)
                            {
                                options.RegisterValidatorsFromAssemblyContaining(item);
                            }
                        });

           


            #region 注入框架
            services.AddMsCloud(builder =>
            {
                builder.AddAspNetCore();
                builder.AddExecl();
                builder.AddSqlSugar();
                builder.AddSwagger();
                builder.AddCors("any");
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("any");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            //app.UseAutoMapper();

            app.UseSwagger(Configuration);

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            //app.UseMiddleware<RealIpMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
            //JobManager.Initialize(new WebServiceRegistry(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()));
            //JobManager.JobException += info => logger.LogError($"�����������{info.Name}-{info.Exception.Message}��", info.Exception);
        }

        public IEnumerable<Type> GetFluentValidationValidator(string assemblyName)
        {
            if (assemblyName == null)
                throw new ArgumentNullException(nameof(assemblyName));
            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));

            var implementAssembly = Assembly.Load(assemblyName);
            if (implementAssembly == null)
            {
                throw new DllNotFoundException($"the dll  not be found");
            }
            var validatorList = implementAssembly.GetTypes().Where(e => e.Name.EndsWith("Validator"));
            return validatorList;
        }
    }
}
