using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LB.Consul.Options
{
    public class DnsEndpoint
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public IPEndPoint ToIPEndPoint() => new IPEndPoint(IPAddress.Parse(this.Address), this.Port);
    }
}