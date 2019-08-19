using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace StackExchangeRedis.RedisHelper
{
    public sealed class RedisConnection
    {

        private static IDatabase _db;
        /// <summary>
        /// redis 连接对象
        /// </summary>
        private static ConnectionMultiplexer _connMultiplexer;
        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object _locker = new object();

        public RedisConnection(string connectionString, string instanceName, int defaultDb)
        {
            var connections = new ConcurrentDictionary<string, ConnectionMultiplexer>().GetOrAdd(instanceName, x => GetConnectionRedisMultiplexer(connectionString));
            _db = connections.GetDatabase(defaultDb);//获取指定的库
        }

        private ConnectionMultiplexer GetConnectionRedisMultiplexer(string connectionString)
        {
            if ((_connMultiplexer == null) || !_connMultiplexer.IsConnected)
            {
                lock (_locker)
                {
                    if ((_connMultiplexer == null) || !_connMultiplexer.IsConnected)
                    {
                        _connMultiplexer = ConnectionMultiplexer.Connect(connectionString);
                    }
                }
            }
            return _connMultiplexer;
        }
        public static IDatabase GetDatabase()
        {
            return _db;
        }
    }
}
