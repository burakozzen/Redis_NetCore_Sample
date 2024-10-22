using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RI_Business.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisIntegration.Controllers
{
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;
        // GET: /<controller>/
        public CacheController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }



        [HttpGet("cache/{key}")]
        public async Task<IActionResult> GetData(string key)
        {
            return Ok(await _redisCacheService.GetValueAsync(key));
        }

        [HttpPost("cache/set")]
        public async Task<IActionResult> SetData(string key, string value)
        {
            await _redisCacheService.SetValueAsync(key, value);
            return Ok();
        }

        [HttpDelete("cache/{key}")]
        public async Task<IActionResult> DeleteData(string key)
        {
            await _redisCacheService.ClearAsync(key);
            return Ok();
        }
    }
}

