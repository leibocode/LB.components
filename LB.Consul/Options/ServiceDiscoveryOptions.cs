using MS.Cloud.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Consul.Options
{
    public class ServiceDiscoveryOptions
    {
        public string ServiceName { get; set; }

        public string Version { get; set; }

        public string HealthCheck { get; set; }

        public string Endpoint { get; set; }

        public ServiceType ServiceType { get; set; } = (ServiceType)0;
    }
}
