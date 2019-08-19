using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeRedis.RedisHelper
{
    internal partial class RedisHelper : IRedisHelper
    {
        private static IDatabase _db;
        internal RedisHelper()
        {
            _db = RedisConnection.GetDatabase();
        }

        #region String Sync

        /// <summary>
        /// 将任何数据以redis string存储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan? timeout = default(TimeSpan?))
        {
            return _db.StringSet(key, CommonTool.Serialize(value), timeout);
        }

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="timeout">过期时间</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, TimeSpan? timeout = default(TimeSpan?))
        {

            return _db.StringSet(key, value, timeout);
        }

        /// <summary>
        /// 从redis string中以指定类型取出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return CommonTool.Deserialize<T>(_db.StringGet(key));
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            return _db.StringGet(key);
        }
        #endregion

        #region String Async

        /// <summary>
        /// 将任何数据以redis string存储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? timeout = default(TimeSpan?))
        {
            return await _db.StringSetAsync(key, CommonTool.Serialize(value), timeout);
        }

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="timeout">过期时间</param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? timeout = default(TimeSpan?))
        {
            return await _db.StringSetAsync(key, value, timeout);
        }


        /// <summary>
        /// 从redis string中以指定类型取出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string key)
        {
            return CommonTool.Deserialize<T>(await _db.StringGetAsync(key, CommandFlags.PreferSlave));
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public async Task<string> StringGetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        #endregion


        #region Key Sync

        /// <summary>
        /// 判断是否存在,存在取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<T>(string key, out T value)
        {
            if (_db.KeyExists(key))
            {
                value = Get<T>(key);
                return true;
            }
            value = default(T);
            return false;
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return _db.KeyExists(key);
        }

        /// <summary>
        /// 删除指定的键。 如果密钥不存在，则忽略该密钥。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyDelete(string key)
        {
            return _db.KeyDelete(key);
        }

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public bool KeyRename(string key, string newKey)
        {
            return _db.KeyRename(key, newKey);
        }

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, TimeSpan? expiry = default(TimeSpan?))
        {
            return _db.KeyExpire(key, expiry);
        }

        #endregion

        #region Key Async
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> KeyExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(key);
        }

        /// <summary>
        /// 删除指定的键。 如果密钥不存在，则忽略该密钥。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> KeyDeleteAsync(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public async Task<bool> KeyRenameAsync(string key, string newKey)
        {
            return await _db.KeyRenameAsync(key, newKey);
        }

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string key, TimeSpan expiry = default(TimeSpan))
        {
            return await _db.KeyExpireAsync(key, expiry);
        }

        #endregion


    }
}
