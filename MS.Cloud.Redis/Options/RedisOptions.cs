using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Cloud.Redis.Options
{
    public class RedisOptions
    {
        public string InstanceName { get; set; }

        public string ConnectionString { get; set; }

        public int DefaultDb { get; set; }
    }
}
