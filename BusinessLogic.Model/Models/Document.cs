using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegistrationNo { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
    }
}
