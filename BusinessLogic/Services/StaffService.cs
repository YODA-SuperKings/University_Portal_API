using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class StaffService : IStaffService
    {
        private readonly IMongoCollection<Staff> _staffCollection;
        public StaffService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _staffCollection = mongoDatabase.GetCollection<Staff>("Staff");
        }
        public List<Staff> GetStaff()
        {
            List<Staff> users;
            users = _staffCollection.Find(emp => true).ToList();
            return users;
        }

        public string CreateStaff(Staff staff)
        {
            string msg = "";
            if (staff != null)
            {
                _staffCollection.InsertOne(staff);
                msg = "Staff added sucessfully.";
            }
            return msg;
        }
    }
}
