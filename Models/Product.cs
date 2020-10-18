using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Size")]
        public string Size { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Brand")]
        public string Brand { get; set; }
    }
}