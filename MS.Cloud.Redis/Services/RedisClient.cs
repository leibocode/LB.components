using MS.Cloud.Redis.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MS.Cloud.Redis.Services
{
    public class RedisClient : IRedisClient
    {
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

        public Task<bool> Lock(string key, int seconds)
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

        public Task<bool> UnLock(string key)
        {
            throw new NotImplementedException();
        }

        bool IRedisClient.Lock(string key, int seconds)
        {
            throw new NotImplementedException();
        }

        bool IRedisClient.UnLock(string key)
        {
            throw new NotImplementedException();
        }
    }
}
