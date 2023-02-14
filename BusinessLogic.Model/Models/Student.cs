using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Model.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string CollegeName { get; set; }
        public string ApplicationType { get; set; }
        public string Semester { get; set; }
        public string CourseAppliedType { get; set; }
        public string SchoolName { get; set; }
        public string GraduatedYear { get; set; }
        public decimal Percentage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Occupation { get; set; }
        public decimal Income { get; set; }
        public string FatherPhoneNumber { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentState { get; set; }
        public string CurrentZipCode { get; set; }
        public string CurrentCountry { get; set; }
        public string UserName { get; set; }
        public int DeptID { get; set; }
        public bool IsActive { get; set; }
    }

    public class StudentRegistrationNumber
    {
        public string label { get; set; }
        public string value { get; set; }
    }
}
