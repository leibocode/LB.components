using LB.Consul.consul;
using LB.Consul.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Cloud.Core.DependencyInjection;
using MS.Cloud.Core.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Consul.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConsul(
          this IServiceCollection services,
          IConfiguration configuration,
          string section = "ServiceDiscovery:Consul")
        {
            services.Configure<ConsulOptions>(configuration.GetSection(section));
            services.AddSingleton<IServiceDiscovery, ConsulServiceDiscovery>();
            return services;
        }

        public static IServiceCollection AddConsul(
          this IMsCloudBuilder builder,
          string section = "ServiceDiscovery:Consul")
        {
            return builder.Services.AddConsul(builder.Configuration, section);
        }
    }
}
