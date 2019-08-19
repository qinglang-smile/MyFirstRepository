using StackExchangeRedis.RedisHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackExchangeRedis
{
    public class RedisProvider
    {
        /// <summary>
        /// 外部访问redis入口，暂时只暴露异步方法
        /// </summary>
        /// <returns></returns>
        public static IRedisHelper CreateRedisRepository()
        {
            return new RedisHelper.RedisHelper();
        }
    }
}
