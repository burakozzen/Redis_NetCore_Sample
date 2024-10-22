using System;
namespace RI_Business.Interfaces
{
	public interface IRedisCacheService
	{
		 Task ClearAsync(string key);
		 Task<string> GetValueAsync(string key);
		 Task<bool> SetValueAsync(string key, string value);
		 void ClearAll();

	}
}

