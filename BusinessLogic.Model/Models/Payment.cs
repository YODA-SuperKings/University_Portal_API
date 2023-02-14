using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegistrationNo { get; set; }
        public string PaymentMode { get; set; }
        public string FeeDescription { get; set; }
        public decimal Amount { get; set; }
        public string AcademicYear { get; set; }
        public string FeeID { get; set; }
        public string currentDate { get; set; }
    }
}
