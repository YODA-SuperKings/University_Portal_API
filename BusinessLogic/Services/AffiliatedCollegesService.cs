using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class AffiliatedCollegesService : IAffiliatedColleges
    {
        private readonly IMongoCollection<AffiliatedColleges> _affiliatedCollegesCollection;
        private readonly IMongoCollection<CollegeRegistration> _collegeRegCollection;
        public AffiliatedCollegesService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _collegeRegCollection = mongoDatabase.GetCollection<CollegeRegistration>("CollegeRegistration");
        }
        public List<AffiliatedColleges> GetAffiliatedColleges()
        {
            List<AffiliatedColleges> affiliatedCollegesList =  new List<AffiliatedColleges>();
            List<CollegeRegistration> collegeRegistration;
            List<CollegeRegistration> collegeRegistration1;
            long govt = 0, sf = 0, ai = 0;
            collegeRegistration = _collegeRegCollection.Find(ac => true && ac.IsActive == true).ToList();
            foreach (var item in collegeRegistration)
            {
                AffiliatedColleges affiliatedColleges = new AffiliatedColleges();
                if (affiliatedCollegesList.FindAll(x => x.District == item.District).Count == 0)
                {
                    collegeRegistration1 = _collegeRegCollection.Find(ac => true && ac.IsActive == true && ac.District == item.District).ToList();
                    govt = 0; sf = 0; ai = 0;
                    foreach (var item1 in collegeRegistration1)
                    {
                        affiliatedColleges.District = item.District;
                        if (item1.Type == "Government")
                            affiliatedColleges.Government += govt + 1;
                        if (item1.Type == "Self Finance")
                            affiliatedColleges.SelfFinanced += sf + 1;
                        if (item1.Type == "Aided")
                            affiliatedColleges.Aided += ai + 1;
                    }
                    affiliatedCollegesList.Add(affiliatedColleges);
                }
            }
            return affiliatedCollegesList;
        }
    }
}
