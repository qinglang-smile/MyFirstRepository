using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace StackExchangeRedis.RedisHelper
{
    internal partial class RedisHelper : IRedisHelper
    {
        #region Hash Sync

        /// <summary>
        /// 判断该字段是否存在 hash 中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HashExists(string key, string field)
        {
            return _db.HashExists(key, field);
        }

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HashDelete(string key, string field)
        {
            return _db.HashDelete(key, field);
        }

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public long HashDelete(string key, IEnumerable<string> hashFields)
        {
            var fields = hashFields.Select(x => (RedisValue)x);
            return _db.HashDelete(key, fields.ToArray());
        }

        /// <summary>
        /// 在 hash 设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HashSet<T>(string key, string field, T value)
        {
            return _db.HashSet(key, field, CommonTool.Serialize(value));
        }

        /// <summary>
        /// 在 hash 中设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        public void HashSet(string key, IEnumerable<KeyValuePair<string, string>> hashFields)
        {
            var entries = hashFields.Select(x => new HashEntry(x.Key, x.Value));
            _db.HashSet(key, entries.ToArray());
        }

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string HashGet(string key, string field)
        {
            return _db.HashGet(key, field);
        }

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public IEnumerable<T> HashGet<T>(string key, IEnumerable<string> hashFields)
        {
            var fields = hashFields.Select(x => (RedisValue)x);
            return CommonTool.DeserializeList<T>(_db.HashGet(key, fields.ToArray()));
        }

        /// <summary>
        /// 从 hash 返回所有的字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> HashKeys<T>(string key)
        {
            return CommonTool.DeserializeList<T>(_db.HashKeys(key));
        }

        /// <summary>
        /// 返回 hash 中的所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> HashValues<T>(string key)
        {
          
            return CommonTool.DeserializeList<T>(_db.HashValues(key));
        }

        /// <summary>
        /// 在 hash 中获取值（反序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public T HashGet<T>(string key, string field)
        {
            return CommonTool.Deserialize<T>(_db.HashGet(key, field));
        }
        #endregion Hash 操作

        #region Hash Async

        /// <summary>
        /// 判断该字段是否存在 hash 中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<bool> HashExistsAsync(string key, string field)
        {
            return await _db.HashExistsAsync(key, field);
        }

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(string key, string field)
        {
            return await _db.HashDeleteAsync(key, field);
        }

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public async Task<long> HashDeleteAsync(string key, IEnumerable<string> hashFields)
        {
            var fields = hashFields.Select(x => (RedisValue)x);
            return await _db.HashDeleteAsync(key, fields.ToArray());
        }

        /// <summary>
        /// 在 hash 设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync(string key, string field, string value)
        {
            return await _db.HashSetAsync(key, field, value);
        }

        /// <summary>
        /// 在 hash 中设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        public async void HashSetAsync(string key, IEnumerable<KeyValuePair<string, string>> hashFields)
        {
            var entries = hashFields.Select(x => new HashEntry(x.Key, x.Value));
            await _db.HashSetAsync(key, entries.ToArray());
        }

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<string> HashGetAsync(string key, string field)
        {
            return await _db.HashGetAsync(key, field);
        }

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> HashGetAsync<T>(string key, IEnumerable<string> hashFields)
        {
            var fields = hashFields.Select(x => (RedisValue)x);
            var value = await _db.HashGetAsync(key, fields.ToArray());
            return  CommonTool.DeserializeList<T>(value);
        }

        /// <summary>
        /// 从 hash 返回所有的字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> HashKeysAsync<T>(string key)
        {
            var value = await _db.HashKeysAsync(key);
            return CommonTool.DeserializeList<T>(value);
        }

        /// <summary>
        /// 返回 hash 中的所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> HashValuesAsync<T>(string key)
        {
            return CommonTool.DeserializeList<T>(await _db.HashValuesAsync(key));
        }

        /// <summary>
        /// 在 hash 设定值（序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync<T>(string key, string field, T redisValue)
        {
            var json = CommonTool.Serialize(redisValue);
            return await _db.HashSetAsync(key, field, json);
        }

        /// <summary>
        /// 在 hash 中获取值（反序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<T> HashGetAsync<T>(string key, string field)
        {
            return CommonTool.Deserialize<T>(await _db.HashGetAsync(key, field));
        }
        #endregion
    }
}
