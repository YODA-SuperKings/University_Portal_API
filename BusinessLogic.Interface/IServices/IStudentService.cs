using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IStudentService
    {
        List<Student> GetStudent();
        string CreateStudent(Student _Student);
        void Update(string id, string regCode, Student student);
    }
}
