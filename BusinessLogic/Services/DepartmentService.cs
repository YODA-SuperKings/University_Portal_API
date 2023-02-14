using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoCollection<Department> _DepartmentCollection;
        public DepartmentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _DepartmentCollection = mongoDatabase.GetCollection<Department>("Department");
        }
        public List<Department> GetDepartment()
        {
            List<Department> department;
            department = _DepartmentCollection.Find(colg => true).ToList();
            return department;
        }
        public string CreateDepartment(Department _Department)
        {
            string msg = "";
            if (_Department != null)
            {
                _DepartmentCollection.InsertOne(_Department);
                msg = "Department addes sucessfully.";
            }
            return msg;
        }
    }
}
