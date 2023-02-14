using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMongoCollection<Payment> _paymentCollection;
        public PaymentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _paymentCollection = mongoDatabase.GetCollection<Payment>("Payment");
        }
        public List<Payment> GetPayment()
        {
            List<Payment> payment;
            payment = _paymentCollection.Find(emp => true).ToList();
            return payment;
        }

        public string CreatePayment(Payment payment)
        {
            string msg = "";
            if (payment != null)
            {
                payment.currentDate = DateTime.Now.ToString();
                _paymentCollection.InsertOne(payment);
                msg = "Fee payment successfull";
            }
            return msg;
        }
    }
}
