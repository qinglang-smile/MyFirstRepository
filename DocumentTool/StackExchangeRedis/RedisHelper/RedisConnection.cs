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

        public RedisConnection(string connectionString, string password, string instanceName, int defaultDb)
        {
            //防止timeout问题
            var config = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                AllowAdmin = true,
                ConnectTimeout = 15000,
                SyncTimeout = 5000,
                // ResponseTimeout = 15000,
                Password = password,//Redis数据库密码
                EndPoints = { connectionString }// connectionString 为IP:Port 如”192.168.2.110:6379”
            };
            //var connect = ConnectionMultiplexer.Connect(config);

            var connections = new ConcurrentDictionary<string, ConnectionMultiplexer>().GetOrAdd(instanceName, x => GetConnectionRedisMultiplexer(config));
            _db = connections.GetDatabase(defaultDb);//获取指定的库
        }

        private ConnectionMultiplexer GetConnectionRedisMultiplexer(ConfigurationOptions config)
        {
            if ((_connMultiplexer == null) || !_connMultiplexer.IsConnected)
            {
                lock (_locker)
                {
                    if ((_connMultiplexer == null) || !_connMultiplexer.IsConnected)
                    {
                        _connMultiplexer = ConnectionMultiplexer.Connect(config);
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
