using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Country 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Countries { get; set; }
    }

    public class Countrry
    {
        public string label { get; set; }
        public string value { get; set; }
    }
}
