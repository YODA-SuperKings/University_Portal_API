using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class ProgramsOfferedService : IProgramsOfferedService
    {
        private readonly IMongoCollection<ProgramsOffered> _programsOfferedCollection;
        public ProgramsOfferedService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _programsOfferedCollection = mongoDatabase.GetCollection<ProgramsOffered>("ProgramsOffered");
        }
        public List<ProgramsOffered> GetProgramsOffered()
        {
            List<ProgramsOffered> programsOffered;
            programsOffered = _programsOfferedCollection.Find(prog => true).ToList();
            return programsOffered;
        }

        public string CreateProgramsOffered(ProgramsOffered programsOffered)
        {
            string msg = "";
            if (programsOffered != null)
            {
                _programsOfferedCollection.InsertOne(programsOffered);
                msg = "Program offered added sucessfully";
            }
            return msg;
        }
    }
}
