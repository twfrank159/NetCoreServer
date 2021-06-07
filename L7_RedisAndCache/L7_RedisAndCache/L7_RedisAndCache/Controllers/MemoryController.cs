using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace L7_RedisAndCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryController : Controller
    {
        private IMemoryCache _cache { get; set; }
        private static IDistributedCache _distributedCache;
        private IDistributedCache _redis { get; set; }

        public MemoryController( IMemoryCache memoryCache, IDistributedCache disCache, IDistributedCache redisCache)
        {
            _cache = memoryCache;
            _redis = redisCache;
            _distributedCache = disCache ?? throw new ArgumentNullException(nameof(disCache));
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return Content($"Memory Cache \n" +
               "[Common]/[distribute]/[redis]");
        }

        [HttpGet("Common")]
        public ActionResult<Dictionary<string, string>> Cache()
        {
            DateTime cacheEntry;

            // 嘗試取得指定的Cache
            if (!_cache.TryGetValue("CachKey", out cacheEntry))
            {
                // 指定的Cache不存在，所以給予一個新的值
                cacheEntry = DateTime.Now;

                // 設定Cache選項
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // 設定Cache保存時間，如果有存取到就會刷新保存時間
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                // 把資料除存進Cache中
                _cache.Set("CachKey", cacheEntry, cacheEntryOptions);
            }

            return new Dictionary<string, string>()
            {
                {"現在時間", DateTime.Now.ToString()},
                {"快取內容", cacheEntry.ToString()}
            };
        }

        [HttpGet("distribute")]
        public IActionResult distribute()
        {
            _distributedCache.Set("Sample", ObjectToByteArray(new UserModel()
            {
                Id = 1,
                Name = "John"
            }));
            var model = ByteArrayToObject<UserModel>(_distributedCache.Get("Sample"));
            return Content($"Cache ID : {model.Id} Cache Name: {model.Name}");
        }

        [HttpGet("redis")]
        public ActionResult<Dictionary<string, string>> RedisGet()
        {
            _redis.Set("RedisTest", ObjectToByteArray(new UserModel()
            {
                Id = 2,
                Name = "Mary"
            }));

            var model = ByteArrayToObject<UserModel>(_redis.Get("RedisTest"));

            return Content($"Cache ID : {model.Id} Cache Name: {model.Name}");
        }

        //物件如果要透過MemoryStream序列化，記得加入[Serializable]標籤
        [Serializable]
        public class UserModel
        {
            public UserModel() { }

            public UserModel(int id_in, string name_in)
            {
                this.Id = id_in;
                this.Name = name_in;
            }
            public int Id { set; get; }
            public string Name { set; get; }


        }

        private byte[] ObjectToByteArray(object obj)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        private T ByteArrayToObject<T>(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var obj = binaryFormatter.Deserialize(memoryStream);
                return (T)obj;
            }
        }
    }
}
