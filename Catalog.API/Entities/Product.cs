using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid  Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
}
