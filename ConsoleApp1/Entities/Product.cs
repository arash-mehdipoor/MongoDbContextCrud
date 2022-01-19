using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
    }
}
