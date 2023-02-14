using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class ExaminationsService : IExaminationsService
    {
        private readonly IMongoCollection<Examinations> _ExaminationsCollection;
        public ExaminationsService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _ExaminationsCollection = mongoDatabase.GetCollection<Examinations>("Examinations");
        }
        public List<Examinations> GetExaminations()
        {
            List<Examinations> examinations;
            examinations = _ExaminationsCollection.Find(emp => true).ToList();
            return examinations;
        }
        public void Update()
        {
            var examinations = _ExaminationsCollection.Find(emp => true).ToList();

            foreach (var item in examinations)
            {
                item.IsPublishedResults = "Published";
                _ExaminationsCollection.ReplaceOneAsync(x => x.Id == item.Id, item);
            }
        }

        public string CreateExaminations(Examinations examinations)
        {
            string msg = "";
            bool IsMarkExists = false;
            if (examinations != null)
            {
                IsMarkExists = _ExaminationsCollection.Find(e => e.RegistrationNo == examinations.RegistrationNo && e.CourseCode == examinations.CourseCode).Any();
                if (IsMarkExists)
                {
                    msg = "Mark already exists.";
                }
                else
                {
                    _ExaminationsCollection.InsertOne(examinations);
                    msg = "Exam marks added sucessfully.";
                }
            }
            return msg;
        }
    }
}
