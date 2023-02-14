using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class FeeService : IFeeService
    {
        private readonly IMongoCollection<Fee> _FeeServiceCollection;
        public FeeService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _FeeServiceCollection = mongoDatabase.GetCollection<Fee>("Fee");
        }
        public List<Fee> GetFee()
        {
            List<Fee> fee;
            fee = _FeeServiceCollection.Find(emp => true).ToList();
            return fee;
        }

        public string CreateFee(Fee fee)
        {
            string msg = "";
            if (fee != null)
            {
                _FeeServiceCollection.InsertOne(fee);
                msg = "Fee added successfully.";
            }
            return msg;
        }
    }
}
