using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Examinations
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegistrationNo { get; set; }
        public string CourseCode { get; set; }
        public string Mark { get; set; }
        public string IsPublishedResults { get; set; }
    }
}
