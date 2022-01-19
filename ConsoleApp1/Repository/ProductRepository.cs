using ConsoleApp1.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class ProductRepository
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<Product> ProductCollection;
        public ProductRepository()
        {
            var client = new MongoClient();
            _db = client.GetDatabase("testDatabase");
            ProductCollection = _db.GetCollection<Product>("Product");
        }

        public void Add(Product product)
        {
            ProductCollection.InsertOne(product);
        }

        public List<Product> GetProducts()
        {
            var product = ProductCollection.Find(new BsonDocument()).ToList();
            return product;
        }

        public Product Find(Guid Id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);
            return ProductCollection.Find(filter).FirstOrDefault();
        }

        public void Edit(Guid Id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);
            var productForUpdate = Builders<Product>.Update
                .Set(p => p.Title, product.Title)
                .Set(p => p.Price, product.Price);

            var result = ProductCollection.UpdateOne(filter, productForUpdate);
            if (result.MatchedCount == 1 && result.ModifiedCount == 1)
            {
                Console.WriteLine("Update");
            }
        }

        public void Delete(Guid Id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);
            ProductCollection.DeleteOne(filter);
        }
    }
}

