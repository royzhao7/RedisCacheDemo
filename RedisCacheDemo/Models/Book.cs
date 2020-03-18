using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisCacheDemo.Models
{
    [Serializable]
    public class Book
    {
        public String isbs { get; set; }
        public String name { get; set; }
        public int price { get; set; }

    }
}