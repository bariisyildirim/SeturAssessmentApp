using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Entity.Models
{
    public class Person
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<Contact> ContactInfo { get; set; } = new(); // en çok halınan hatalardan birisi new lememek! (null pointer exception)
    }
}
