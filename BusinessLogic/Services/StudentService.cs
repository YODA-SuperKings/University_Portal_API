using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _studentCollection;
        public StudentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _studentCollection = mongoDatabase.GetCollection<Student>("Student");
        }
        public List<Student> GetStudent()
        {
            List<Student> student;
            student = _studentCollection.Find(student => true).ToList();
            return student;
        }

        public List<StudentRegistrationNumber> GetRegistrationNumbers()
        {
            List<StudentRegistrationNumber> regNo =  new List<StudentRegistrationNumber>();
            List<Student> student;
            student = _studentCollection.Find(student => true).ToList();
            foreach (var item in student)
            {
                StudentRegistrationNumber sregNo = new StudentRegistrationNumber();
                if (item.RegistrationNo != null)
                {
                    sregNo.label = item.RegistrationNo;
                    sregNo.value = item.RegistrationNo;
                }
                regNo.Add(sregNo);
            }
            return regNo;
        }

        public void Update(string id, string regCode, Student student)
        {
            _studentCollection.ReplaceOneAsync(x => x.Id == id && x.RegistrationNo == regCode, student);
        }

        public string CreateStudent(Student student)
        {
            string msg = "";
            bool IsEmailExists = _studentCollection.Find(c => c.Email == student.Email).Any();
            if (student != null)
            {
                if (IsEmailExists)
                {
                    msg = "Email already exists.";
                }
                else
                {
                    var item = _studentCollection.Find(d => true).Limit(1);
                    if(item != null)
                    {
                        int _registrationNo = Convert.ToInt32(item.FirstOrDefault().RegistrationNo) + 1;
                        student.RegistrationNo = _registrationNo.ToString();
                    }
                    _studentCollection.InsertOne(student);
                    msg = "Admission details saved successfully";
                }
            }
            return msg;
        }
    }
}
