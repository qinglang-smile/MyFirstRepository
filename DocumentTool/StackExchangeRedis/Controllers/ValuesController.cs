using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchangeRedis.RedisHelper;

namespace StackExchangeRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRedisHelper _redis;
        public ValuesController()
        {
            _redis = RedisProvider.CreateRedisRepository();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //1)测试String
            _redis.Set<string>("one", "one", TimeSpan.FromSeconds(10));
            _redis.Set<int>("two", 2, TimeSpan.FromSeconds(10));

            var one = _redis.StringGet("one");
            var two = _redis.Get<int>("two");

            //2)测试List
            var temp = new
            {
                Value = "489772",
                LinkedPrimaryKey = 56,
                StorageData = "18476686118",
                IsDeleted = 0,
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = DateTime.UtcNow
            };
            _redis.ListRightPush("list1", temp);

            var temp2 = new
            {
                Value = "489123",
                LinkedPrimaryKey = 56,
                StorageData = "18476686118",
                IsDeleted = 0,
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = DateTime.UtcNow
            };
            _redis.ListRightPush("list1", temp2);

            var list = _redis.ListRange<AuthenticationCode>("list1");

            //3)测试Hash

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                ["Hash1"] = "1",
                ["Hash2"] = "2",
                ["Hash3"] = "3",
            };

            _redis.HashSet("Hash", dictionary);


            var hash = _redis.HashGet<string>("Hash", new List<string> { "Hash1", "Hash2" });

            //4)测试SortedSet
            _redis.SortedSetAdd("sorted", 1, 1);
            _redis.SortedSetAdd("sorted2", 2, 2);


            var sorted = _redis.SortedSetRangeByRank<string>("sorted2");
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
    public class AuthenticationCode 
    {
       
        public int AuthenticationCodeId { get; set; }

        public string Value { get; set; }

       

        public byte LinkedType { get; set; }

        public int LinkedPrimaryKey { get; set; }

      

        public byte Scene { get; set; }

        public string StorageData { get; set; } = string.Empty;
    }
}
