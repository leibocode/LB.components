using LB.Consul.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Cloud.Core.Models;
using MS.Cloud.Core.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Consul.Extensions
{
    /// <summary>
    /// 主要做注入consul
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseConsul(
          this IApplicationBuilder app,
          IConfiguration configuration,
          string section = "ServiceDiscovery")
        {
            ServiceDiscoveryOptions options = configuration.GetSection(section).Get<ServiceDiscoveryOptions>();
            app.UseConsul(options);
            return app;
        }

        public static IApplicationBuilder UseConsul(
          this IApplicationBuilder app,
          ServiceDiscoveryOptions options)
        {
            IApplicationLifetime applicationLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>() ?? throw new ArgumentException("Missing Dependency", "IApplicationLifetime");
            if (string.IsNullOrEmpty(options.ServiceName))
                throw new ArgumentException("service name must be configure", "ServiceName");
            Uri uri1;
            if (!string.IsNullOrWhiteSpace(options.Endpoint))
            {
                uri1 = new Uri(options.Endpoint);
            }
            else
            {
                IServerAddressesFeature addressesFeature = (app.Properties["server.Features"] as FeatureCollection).Get<IServerAddressesFeature>();
                Uri uri2;
                if (addressesFeature == null)
                {
                    uri2 = null;
                }
                else
                {
                    ICollection<string> addresses = addressesFeature.Addresses;
                    if (addresses == null)
                    {
                        uri2 = null;
                    }
                    else
                    {
                        IEnumerable<Uri> source = addresses.Select(p => new Uri(p));
                        uri2 = source != null ? source.FirstOrDefault<Uri>() : (Uri)null;
                    }
                }
                uri1 = uri2;
            }
            if (uri1 != (Uri)null)
            {
                Console.WriteLine(string.Format("Address:{0}", (object)uri1));
                Uri healthCheckUri = (Uri)null;
                if (!string.IsNullOrEmpty(options.HealthCheck))
                {
                    Console.WriteLine(string.Format("HealthCheckUrl:{0}{1}", uri1,options.HealthCheck));
                    healthCheckUri = new Uri(string.Format("{0}{1}", uri1,options.HealthCheck));
                }
                ServiceInformation registryInformation = app.AddTenant(options.ServiceName, options.Version, uri1, options.ServiceType, healthCheckUri, (IEnumerable<string>)new string[1]
                {
                    "urlprefix-/" + options.ServiceName
                });
                applicationLifetime.ApplicationStopping.Register((Action)(() => app.RemoveTenant(registryInformation.Id)));
            }
            return app;
        }

        public static ServiceInformation AddTenant(
          this IApplicationBuilder app,
          string serviceName,
          string version,
          Uri uri,
          ServiceType serviceType = 0,
          Uri healthCheckUri = null,
          IEnumerable<string> tags = null)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            return app.ApplicationServices.GetRequiredService<IServiceDiscovery>().RegisterServiceAsync(serviceName, version, uri, serviceType, healthCheckUri, tags).Result;
        }

        public static bool RemoveTenant(this IApplicationBuilder app, string serviceId)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentNullException(nameof(serviceId));
            return app.ApplicationServices.GetRequiredService<IServiceDiscovery>().DeregisterServiceAsync(serviceId).Result;
        }
    }
}
