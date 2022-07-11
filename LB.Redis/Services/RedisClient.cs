using LB.Redis.abstractions;
using LB.Redis.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace LB.Redis.Services
{
    public class RedisClient : IRedisClient, IDisposable
    {
        private readonly RedisOptions _options;
     
        private readonly object redisConnectionLock = new object();

        public RedisClient(IOptionsMonitor<RedisOptions> optionsMonitor)
        {
            this._options = optionsMonitor.CurrentValue;
        }

       

        public IRedisClient ChangeDataBase(int db)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool Lock(string key, int seconds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LockAsync(string key, int seconds)
        {
            throw new NotImplementedException();
        }

        public bool Set(string key, string value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }

        public bool Set(string key, string value, int seconds)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, int seconds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync(string key, string value, int seconds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync<T>(string key, T value, int seconds)
        {
            throw new NotImplementedException();
        }

        public bool UnLock(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnLockAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
