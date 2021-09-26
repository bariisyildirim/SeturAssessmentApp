using MongoDB.Driver;
using Setur.Data.Models;
using Setur.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _Persons;

        public PersonRepository(IPersonDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Persons = database.GetCollection<Person>(settings.PeopleCollectionName);
        }

        public List<Person> Get() =>
            _Persons.Find(Person => true).ToList();

        public Person Get(string id) =>
            _Persons.Find<Person>(Person => Person.Id == id).FirstOrDefault();

        public Person Create(Person Person)
        {
            _Persons.InsertOne(Person);
            return Person;
        }

        public void Update(Person person) =>
            _Persons.ReplaceOne(Person => Person.Id == person.Id, person);

        public void Remove(Person PersonIn) =>
            _Persons.DeleteOne(Person => Person.Id == PersonIn.Id);

        public void Remove(string id) =>
            _Persons.DeleteOne(Person => Person.Id == id);
    }
}
