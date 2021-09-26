using Setur.Data.Repositories;
using Setur.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Business.Services
{
   public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<Person> Get() =>
           _personRepository.Get();

        public Person Get(string id) =>
            _personRepository.Get(id);

        public Person Create(Person Person)
        {
            _personRepository.Create(Person);
            return Person;
        }

        public void Update(Person person) =>
            _personRepository.Update(person);

        public void Remove(Person PersonIn) =>
            _personRepository.Remove(PersonIn);

        public void Remove(string id) =>
            _personRepository.Remove(id);
    }
}
