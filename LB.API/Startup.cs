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
            services.AddControllers();

            #region ×¢Èë¿ò¼Ü
            services.AddMsCloud(builder =>
            {
                builder.AddAspNetCore();
                builder.AddExecl();
                builder.AddSwagger();
                builder.AddCors("cors");
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseSwagger(Configuration);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
