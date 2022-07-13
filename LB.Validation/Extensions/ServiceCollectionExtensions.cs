using Microsoft.Extensions.DependencyInjection;
using MS.Cloud.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;

namespace LB.Validation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services,string section)
        {

            services.AddFluentValidation(options =>
            {
               
                var implementAssembly = Assembly.Load(section);
                if (implementAssembly == null)
                {
                    throw new DllNotFoundException($"the dll not be found");
                }
                var validatorList = implementAssembly.GetTypes().Where(e => e.Name.EndsWith("Validator"));

                foreach (var item in validatorList)
                {
                    options.RegisterValidatorsFromAssemblyContaining(item);
                }
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState
                        .Values
                        .SelectMany(x => x.Errors
                                    .Select(p => p.ErrorMessage))
                        .ToList();

                    var result = new
                    {
                        status = 400,
                        Message = $"入参校验失败:{string.Join(",", errors.Select(e => string.Format("{0}", e)).ToList())}",
                        Errors = errors
                    };

                    return new BadRequestObjectResult(result);
                };
            });

            return services;
        }

        public static IServiceCollection AddFluentValidation(
         this IMsCloudBuilder builder,string section)
        {
            return builder.Services.AddFluentValidation(section);
        }

    }
}
