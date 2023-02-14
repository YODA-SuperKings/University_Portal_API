using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class ProgramsOffered
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string slno { get; set; }
        public string Course { get; set; }
        public string CourseName { get; set; }
        public string Type { get; set; }
        public decimal FeeAmount { get; set; }
        public string Year { get; set; }
        public string Dept { get; set; }
    }
}
