using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMongoCollection<Document> _DocumentCollection;
        public DocumentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _DocumentCollection = mongoDatabase.GetCollection<Document>("Document");
        }
        public List<Document> GetDocument()
        {
            List<Document> document;
            document = _DocumentCollection.Find(emp => true).ToList();
            return document;
        }

        public string CreateDocument(Document document)
        {
            string msg = "";
            if (document != null)
            {
                _DocumentCollection.InsertOne(document);
                msg = "Document saved successfully";
            }

            return msg;
        }

        public void Update(string id, string regCode, Document document)
        {
            _DocumentCollection.ReplaceOneAsync(x => x.Id == id && x.RegistrationNo == regCode, document);
        }
    }
}
