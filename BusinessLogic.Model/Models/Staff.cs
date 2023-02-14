using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string DeptID { get; set; }
        public string IsActive { get; set; }

    }
}
