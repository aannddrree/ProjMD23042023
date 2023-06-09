﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjMB23042023.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
