using Consul;
using LB.Consul.Options;
using Microsoft.Extensions.Options;
using MS.Cloud.Core.Extensions;
using MS.Cloud.Core.Models;
using MS.Cloud.Core.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LB.Consul.consul
{
    public class ConsulServiceDiscovery : IServiceDiscovery, IResolveServiceInstance
    {
        private const string VERSION_PREFIX = "version-";
        private readonly ConsulOptions _configuration;
        private readonly ConsulClient _consul;

        public ConsulServiceDiscovery(IOptions<ConsulOptions> options)
        {
            this._configuration = options.Value;
            this._consul = new ConsulClient(config =>
            {
                config.Address = new Uri(this._configuration.HttpEndpoint);
                if (string.IsNullOrEmpty(this._configuration.Datacenter))
                    return;
                config.Datacenter = this._configuration.Datacenter;
            });
        }

        private string GetServiceId(string serviceName, Uri uri)
        {
            return string.Format("{0}_{1}_{2}", serviceName, uri.Host.Replace(".", "_"), uri.Port);
        }

        /// <summary>
        /// 把一个服务注入到consul中
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="version"></param>
        /// <param name="uri"></param>
        /// <param name="serviceType"></param>
        /// <param name="healthCheckUri"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<ServiceInformation> RegisterServiceAsync(
          string serviceName,
          string version,
          Uri uri,
          ServiceType serviceType = 0,
          Uri healthCheckUri = null,
          IEnumerable<string> tags = null)
        {
            string serviceId = this.GetServiceId(serviceName, uri);
            string checkUrl = healthCheckUri?.ToString() ?? string.Format("{0}",uri).TrimEnd('/') + "/api/health";
            if (((int)serviceType)==1)
                checkUrl = healthCheckUri == null ? string.Format("{0}:{1}",uri.Host,uri.Port) : string.Format("{0}:{1}", healthCheckUri.Host, healthCheckUri.Port);
            AgentServiceCheck httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = new TimeSpan?(TimeSpan.FromSeconds(5.0)),
                Interval = new TimeSpan?(TimeSpan.FromSeconds(10.0)),
                HTTP = serviceType.ToString() == null ? checkUrl :null,
                TCP = ((int)serviceType) == 1 ? checkUrl :null,
                Timeout = new TimeSpan?(TimeSpan.FromSeconds(10.0))
            };
            string versionLabel = "version-" + version;
            List<string> tagList = (tags ?? Enumerable.Empty<string>()).ToList<string>();
            tagList.Add(versionLabel);
            AgentServiceRegistration registration = new AgentServiceRegistration()
            {
                ID = serviceId,
                Name = serviceName,
                Tags = tagList.ToArray(),
                Address = uri.Host,
                Port = uri.Port,
                Check = httpCheck
            };
            WriteResult writeResult = await this._consul.Agent.ServiceRegister(registration);
            ServiceInformation serviceInformation = new ServiceInformation()
            {
                Name = registration.Name,
                Id = registration.ID,
                HostAndPort = new HostAndPort(registration.Address, registration.Port),
                Version = version,
                Tags = tagList
            };
            return serviceInformation;
        }

        /// <summary>
        /// 注销consul服务
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public async Task<bool> DeregisterServiceAsync(string serviceId)
        {
            WriteResult writeResult = await this._consul.Agent.ServiceDeregister(serviceId);
            bool flag = writeResult.StatusCode == HttpStatusCode.OK;
            return flag;
        }

        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        private string GetVersionFromStrings(IEnumerable<string> strings)
        {
            return strings
               ?.FirstOrDefault(x => x.StartsWith(VERSION_PREFIX, StringComparison.Ordinal))
               .TrimStart(VERSION_PREFIX);
        }

        /// <summary>
        /// 获取服务目录
        /// </summary>
        /// <returns></returns>
        private async Task<IDictionary<string, string[]>> GetServicesCatalogAsync()
        {
            var queryResult = await _consul.Catalog.Services(); // local agent datacenter is implied
            var services = queryResult.Response;

            return services;
        }

        /// <summary>
        /// 查找服务
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ServiceInformation>> FindServiceInstancesAsync()
        {
            var instancesWithLambdaAsync = await this.FindServiceInstancesWithLambdaAsync(nameTagsPredicate: x => true, ServiceInformationPredicate:x=>true);
            return instancesWithLambdaAsync;
        }

        /// <summary>
        /// 根据名称查找服务
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IList<ServiceInformation>> FindServiceInstancesAsync(
          string name)
        {
            var queryResult = await this._consul.Health.Service(name, "", true);
            var instances = queryResult.Response.Select(
                serviceEntry => new ServiceInformation
                {
                    Name = serviceEntry.Service.Service,
                    HostAndPort = new HostAndPort(serviceEntry.Service.Address, serviceEntry.Service.Port),
                    Version = this.GetVersionFromStrings((IEnumerable<string>)serviceEntry.Service.Tags),
                    Tags = (IEnumerable<string>)serviceEntry.Service.Tags ?? Enumerable.Empty<string>(),
                    Id = serviceEntry.Service.ID
                });
            var list = instances.ToList();
            return list;
        }

        /// <summary>
        /// 根据服务状态查找服务
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passingOnly"></param>
        /// <returns></returns>
        public async Task<IList<ServiceInformation>> FindServiceInstancesWithStatusAsync(
          string name,
          bool passingOnly = true)
        {
           var queryResult = await this._consul.Health.Service(name, "", passingOnly);
           var instances = queryResult.Response.Select(serviceEntry => new ServiceInformation()
            {
                Name = serviceEntry.Service.Service,
                HostAndPort = new HostAndPort(serviceEntry.Service.Address, serviceEntry.Service.Port),
                Version = this.GetVersionFromStrings((IEnumerable<string>)serviceEntry.Service.Tags),
                Tags = (IEnumerable<string>)serviceEntry.Service.Tags ?? Enumerable.Empty<string>(),
                Id = serviceEntry.Service.ID
            });
            var list = (IList<ServiceInformation>)instances.ToList<ServiceInformation>();
            return list;
        }

        /// <summary>
        /// 根据名称和版本号查找服务
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public async Task<IList<ServiceInformation>> FindServiceInstancesWithVersionAsync(
          string name,
          string version)
        {
            var instances = await this.FindServiceInstancesAsync(name);
            var range = new SemVer.Range(version);

            return instances.Where(x => range.IsSatisfied(x.Version)).ToArray();
        }

        public async Task<IList<ServiceInformation>> FindServiceInstancesWithLambdaAsync(
          Predicate<KeyValuePair<string, string[]>> nameTagsPredicate,
          Predicate<ServiceInformation> ServiceInformationPredicate)
        {
            var servicesCatalogAsync = await this.GetServicesCatalogAsync();
            return servicesCatalogAsync.Where(kvp => nameTagsPredicate(kvp))
                .Select(kvp => kvp.Key)
                .Select(FindServiceInstancesAsync)
                .SelectMany(task => task.Result)
                .ToList();
        }
    }
}
