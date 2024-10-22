using System;
using RI_Business.Interfaces;
using StackExchange.Redis;

namespace RI_Business.Services
{
	public class RedisCacheService:IRedisCacheService
	{
		private readonly IConnectionMultiplexer _connectionMultiplexer;
		private readonly IDatabaseAsync _databaseAsync;

		public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;
			_databaseAsync = _connectionMultiplexer.GetDatabase();
		}

        public void ClearAll()
        {
            var redisEndPoints = _connectionMultiplexer.GetEndPoints(true);
            foreach(var redisEndPoint in redisEndPoints)
            {
                var redisServer = _connectionMultiplexer.GetServer(redisEndPoint);
                redisServer.FlushAllDatabases();
            }
        }

        public async Task ClearAsync(string key)
        {
            await _databaseAsync.KeyDeleteAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _databaseAsync.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _databaseAsync.StringSetAsync(key, value);
        }
    }
}

