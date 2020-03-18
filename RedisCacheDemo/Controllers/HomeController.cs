using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;
using RedisCacheDemo.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RedisCacheDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConnectionMultiplexer con=StackExchange.Redis.ConnectionMultiplexer.Connect("chf.redis.cache.chinacloudapi.cn:6380,password=POc24ppQX3IAGNNncgSIAhwcI2xQtkX64tcLa3+5t8U=,ssl=True,abortConnect=False");
            IDatabase cache=con.GetDatabase();
            cache.StringSet("key", "value");
            String value = cache.StringGet("key");
            Book bk = new Book();
            bk.isbs = "1234";
            bk.name = "Azure";
            bk.price = 123;
            RedisKey k = new RedisKey();
            k = "book";
            RedisValue v = new RedisValue();
            //serialize book
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, bk);
            byte[] buf = ms.ToArray();
            ms.Flush();
            ms.Close();
            v = buf;
            cache.StringSet(k, v);

            Book bk2;
            buf = cache.StringGet("book");
            ms = new MemoryStream(buf);
            bf = new BinaryFormatter();
            bk2=(Book)bf.Deserialize(ms);

            
            ViewData["book"] = bk2;
            ViewData["key"] = value;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}