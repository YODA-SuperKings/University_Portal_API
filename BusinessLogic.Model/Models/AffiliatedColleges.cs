using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model.Models
{
    public class AffiliatedColleges
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string District { get; set; }
        public long Government { get; set; }
        public long Aided { get; set; }
        public long SelfFinanced { get; set; }
    }
}
