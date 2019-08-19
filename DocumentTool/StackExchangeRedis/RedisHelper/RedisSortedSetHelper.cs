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
        #region SortedSet Sync

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd<T>(string key, T value, double score)
        {
            return _db.SortedSetAdd(key, CommonTool.Serialize(value), score);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove<T>(string key, T value)
        {
            return  _db.SortedSetRemove(key, CommonTool.Serialize(value));
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> SortedSetRangeByRank<T>(string key)
        {
            return CommonTool.DeserializeList<T>(_db.SortedSetRangeByRank(key)) ;
        }
        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long SortedSetLength(string key)
        {
            return _db.SortedSetLength(key);
        }

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SortedSetLength(string key, string value)
        {
            return _db.SortedSetRemove(key, value);
        }


        #endregion SortedSet 操作

        #region SortedSet Async

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public async Task<bool> SortedSetAddAsync<T>(string key, T value, double score)
        {
            return await _db.SortedSetAddAsync(key, CommonTool.Serialize(value), score);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async Task<bool> SortedSetRemoveAsync<T>(string key, T value)
        {
            return await _db.SortedSetRemoveAsync(key, CommonTool.Serialize(value));
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SortedSetRangeByRankAsync<T>(string key)
        {
            return CommonTool.DeserializeList<T>(await _db.SortedSetRangeByRankAsync(key));
        }

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<long> SortedSetLengthAsync(string key)
        {
            return await _db.SortedSetLengthAsync(key);
        }

        /// <summary>
        /// 返回有序集合的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetRemoveAsync(string key, string member)
        {
            return await _db.SortedSetRemoveAsync(key, member);
        }

        #endregion

    }
}
