using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<Users> _usersCollection;
        public UsersService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<Users>("Users");
        }
        public List<Users> GetUsers()
        {
            List<Users> users;
            users = _usersCollection.Find(emp => true).ToList();
            return users;
        }

        public string CreateUser(Users user)
        {
            string msg = "";
            bool isUserExists = _usersCollection.Find(usr => usr.Email == user.Email).Any() ? true : false;
            bool isNameExists = _usersCollection.Find(usr => usr.Name == user.Name).Any() ? true : false;
            if (isUserExists)
            {
                msg = "User email already exists.";
            }
            else if(user != null)
            {
                _usersCollection.InsertOne(user);
                msg = "User added sucessfully.";
            }
          
            return msg;
        }
    }
}
