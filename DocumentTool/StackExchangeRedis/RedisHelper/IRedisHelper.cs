using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace StackExchangeRedis.RedisHelper
{
    public interface IRedisHelper
    {
        #region String 操作

        #region Sync
        /// <summary>
        /// 将任何数据以redis string存储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, TimeSpan? timeout = null);

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        bool StringSet(string key, string value, TimeSpan? timeout = default(TimeSpan?));

        /// <summary>
        /// 从redis string中以指定类型取出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        string StringGet(string key);

        #endregion

        #region Async
        /// <summary>
        /// 将任何数据以redis string存储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<bool> SetAsync<T>(string key, T value, TimeSpan? timeout = default(TimeSpan?));

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="timeout">过期时间</param>
        /// <returns></returns>
        Task<bool> StringSetAsync(string key, string value, TimeSpan? timeout = default(TimeSpan?));

        /// <summary>
        /// 从redis string中以指定类型取出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        Task<string> StringGetAsync(string key);


        #endregion

        #endregion

        #region List 操作

        #region Sync

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListLeftPop(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListRightPop(string key);

        /// <summary>
        /// 移除列表指定键上与该值相同的元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRemove(string key, string value);

        /// <summary>
        /// 在列表头部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, string value);

        /// <summary>
        /// 在列表尾部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, string value);

        /// <summary>
        /// 返回列表上该键的长度，如果不存在，返回 0
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long ListLength(string key);

        /// <summary>
        /// 返回在该列表上键所对应的元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<T> ListRange<T>(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T ListLeftPop<T>(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T ListRightPop<T>(string key);

        /// <summary>
        /// 在列表头部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush<T>(string key, T value);

        /// <summary>
        /// 在列表尾部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush<T>(string key, T value);

        #endregion

        #region Async

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListLeftPopAsync(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListRightPopAsync(string key);

        /// <summary>
        /// 移除列表指定键上与该值相同的元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, string value);

        /// <summary>
        /// 在列表头部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, string value);

        /// <summary>
        /// 在列表尾部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, string value);

        /// <summary>
        /// 返回列表上该键的长度，如果不存在，返回 0
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<long> ListLengthAsync(string key);

        /// <summary>
        /// 返回在该列表上键所对应的元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<RedisValue>> ListRangeAsync(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> ListLeftPopAsync<T>(string key);

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> ListRightPopAsync<T>(string key);

        /// <summary>
        /// 在列表头部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync<T>(string key, T value);

        /// <summary>
        /// 在列表尾部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync<T>(string key, T value);


        #endregion

        #endregion

        #region Hash 操作

        #region Sync

        /// <summary>
        /// 判断该字段是否存在 hash 中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool HashExists(string key, string field);

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool HashDelete(string key, string field);

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        long HashDelete(string key, IEnumerable<string> hashFields);

        /// <summary>
        /// 在 hash 中设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        void HashSet(string key, IEnumerable<KeyValuePair<string, string>> hashFields);

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        string HashGet(string key, string field);

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        IEnumerable<T> HashGet<T>(string key, IEnumerable<string> hashFields);

        /// <summary>
        /// 从 hash 返回所有的字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<T> HashKeys<T>(string key);

        /// <summary>
        /// 返回 hash 中的所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<T> HashValues<T>(string key);

        /// <summary>
        /// 在 hash 设定值（序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        bool HashSet<T>(string key, string field, T redisValue);

        /// <summary>
        /// 在 hash 中获取值（反序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        T HashGet<T>(string key, string field);

        #endregion

        #region Async

        /// <summary>
        /// 判断该字段是否存在 hash 中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<bool> HashExistsAsync(string key, string field);

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<bool> HashDeleteAsync(string key, string field);

        /// <summary>
        /// 从 hash 中移除指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        Task<long> HashDeleteAsync(string key, IEnumerable<string> hashFields);

        /// <summary>
        /// 在 hash 设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string field, string value);

        /// <summary>
        /// 在 hash 中设定值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        void HashSetAsync(string key, IEnumerable<KeyValuePair<string, string>> hashFields);

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<string> HashGetAsync(string key, string field);

        /// <summary>
        /// 在 hash 中获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> HashGetAsync<T>(string key, IEnumerable<string> hashFields);

        /// <summary>
        /// 从 hash 返回所有的字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> HashKeysAsync<T>(string key);

        /// <summary>
        /// 返回 hash 中的所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> HashValuesAsync<T>(string key);

        /// <summary>
        /// 在 hash 设定值（序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync<T>(string key, string field, T redisValue);

        /// <summary>
        /// 在 hash 中获取值（反序列化）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<T> HashGetAsync<T>(string key, string field);

        #endregion

        #endregion

        #region SortedSet 操作

        #region Sync

        /// <summary>
        /// SortedSet 新增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        bool SortedSetAdd<T>(string key, T value, double score);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove<T>(string key, T value);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<T> SortedSetRangeByRank<T>(string key);

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long SortedSetLength(string key);

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        bool SortedSetLength(string key, string member);
        #endregion

        #region Async

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync<T>(string key, T value, double score);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync<T>(string key, T value);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SortedSetRangeByRankAsync<T>(string key);

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<long> SortedSetLengthAsync(string key);

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        Task<bool> SortedSetRemoveAsync(string key, string member);

        #endregion

        #endregion

        #region Key 操作

        #region Sync
        /// <summary>
        /// 判断是否存在,存在取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue<T>(string key, out T value);

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool KeyExists(string key);

        /// <summary>
        /// 删除指定的键。 如果密钥不存在，则忽略该密钥。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool KeyDelete(string key);

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        bool KeyRename(string key, string newKey);

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        bool KeyExpire(string key, TimeSpan? expiry = default(TimeSpan?));



        #endregion

        #region Async

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> KeyExistsAsync(string key);

        /// <summary>
        /// 删除指定的键。 如果密钥不存在，则忽略该密钥。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> KeyDeleteAsync(string key);

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        Task<bool> KeyRenameAsync(string key, string newKey);

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        Task<bool> KeyExpireAsync(string key, TimeSpan expiry = default(TimeSpan));

        #endregion


        #endregion

    }
}
