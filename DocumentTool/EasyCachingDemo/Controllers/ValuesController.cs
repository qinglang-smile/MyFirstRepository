using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEasyCachingProvider _provider;//单个使用
        private readonly IRedisCachingProvider _redisCachingProvider;//多个使用
        public ValuesController(IEasyCachingProvider provider,
            IEasyCachingProviderFactory factory)
        {
            _provider = provider;
            _redisCachingProvider = factory.GetRedisProvider("redis1");
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //单个设置值
            _provider.Set("single", 1, TimeSpan.FromSeconds(6));
            int id = _provider.Get<int>("single").Value;


            //多个设置值
            _redisCachingProvider.StringSet("multi", "multi", TimeSpan.FromSeconds(6));
            string ids = _redisCachingProvider.StringGet("multi");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
