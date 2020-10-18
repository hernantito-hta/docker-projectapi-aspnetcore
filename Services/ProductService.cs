using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("ProductDB"));
            // Gets the productDB.
            var database = client.GetDatabase("ProductDB");
            //Fetches the product collection.
            _product = database.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> Get()
        {
            //Gets all products. 
            return await _product.Find(s => true).ToListAsync();
        }

        public async Task<Product> Get(string id)
        {
            //Get a single product. 
            return await _product.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Create(Product result)
        {
            //Create a product.
            await _product.InsertOneAsync(result);
            return result;
        }

        public async Task<Product> Update(string id, Product item)
        {
            // Updates and existing product. 
             await _product.ReplaceOneAsync(su => su.Id == id, item);
             return item;
        }


        public async Task Remove(string id)
        {
            //Removes a product.
            await _product.DeleteOneAsync(su => su.Id == id);
        }

    }
}