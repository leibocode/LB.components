using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Consul.Options
{
    public class ConsulOptions
    {
        public string HttpEndpoint { get; set; }

        public DnsEndpoint DnsEndpoint { get; set; }

        public string Datacenter { get; set; }

        public string AclToken { get; set; }

        public TimeSpan? LongPollMaxWait { get; set; }

        public TimeSpan? RetryDelay { get; set; } = new TimeSpan?(TimeSpan.FromSeconds(15.0));


    }
}
