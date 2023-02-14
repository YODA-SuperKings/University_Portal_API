using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Syllabus
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CourseCode { get; set; }
        public string Part { get; set; }
        public string CourseTitle { get; set; }
        public string Hours { get; set; }
        public string Credit { get; set; }
        public string CIA { get; set; }
        public string ESE { get; set; }
        public string Total { get; set; }
        public string SemesterType { get; set; }
        public string ProgramId { get; set; }
}
}
