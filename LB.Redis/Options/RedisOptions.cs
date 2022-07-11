using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Redis.Options
{
    public class RedisOptions
    {
        public string InstanceName { get; set; }

        public string ConnectionString { get; set; }

        public int DefaultDb { get; set; } = 0;

        public string Password { get; set; }
    }
}
