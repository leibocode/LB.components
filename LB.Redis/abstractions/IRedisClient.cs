using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LB.Redis.abstractions
{
    public interface IRedisClient
    {
        IRedisClient ChangeDataBase(int db);

        bool Set(string key, string value, TimeSpan? expiry = null);

        bool Set(string key, string value, int seconds);

        bool Set<T>(string key, T value, TimeSpan? expiry = null);

        bool Set<T>(string key, T value, int seconds);

        T Get<T>(string key);

        string Get(string key);

        bool Delete(string key);

        bool Exists(string key);

        Task<bool> SetAsync(string key, string value, TimeSpan? expiry = null);

        Task<bool> SetAsync(string key, string value, int seconds);

        Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null);

        Task<bool> SetAsync<T>(string key, T value, int seconds);

        Task<bool> DeleteAsync(string key);

        Task<string> GetAsync(string key);

        Task<T> GetAsync<T>(string key);

        Task<bool> LockAsync(string key, int seconds);

        Task<bool> UnLockAsync(string key);

        bool Lock(string key, int seconds);

        bool UnLock(string key);
    }
}
