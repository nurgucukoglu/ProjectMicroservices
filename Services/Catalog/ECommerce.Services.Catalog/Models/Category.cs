using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //ilgili prop.un id olduğunu ve guid olduğunu belirtir.
        public string Id { get; set; }
        public string Name { get; set; }


    }
}
