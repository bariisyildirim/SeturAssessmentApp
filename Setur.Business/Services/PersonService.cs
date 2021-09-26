using Setur.Business.Models;
using Setur.Data.Repositories;
using Setur.Entity.Models;
using Setur.Entity.Models.Enums;
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

        public List<LocationReport> Report()
        {
            List<Person> data = Get();

            List<LocationReport> reportList = new List<LocationReport>();

            foreach (var item in data)
            {
                foreach (var contact in item.ContactInfo)
                {
                    if (contact.Type == InformationType.Location)
                    {
                        LocationReport locationReport = reportList.FirstOrDefault<LocationReport>(x => x.LocationName == contact.Content);

                        var hasPhoneNumber = item.ContactInfo.FirstOrDefault(s => s.Type == InformationType.PhoneNumber);

                        if (locationReport != null)
                        {
                            if (hasPhoneNumber != null)
                            {
                                locationReport.PeoplePhoneNumberCount += 1;
                            }
                            
                            reportList.Remove(locationReport);
                            locationReport.LocationCount += 1;
                            reportList.Add(locationReport);
                        }
                        else
                        {
                            reportList.Add(new LocationReport
                            {
                                LocationCount = 1,
                                LocationName = contact.Content,
                                PeoplePhoneNumberCount = hasPhoneNumber == null?0:1
                            });
                        }
                    }
                }
            }

            return reportList.OrderByDescending(s=>s.LocationCount).ToList();
        }

        public Person AddContact(string id, Contact contact)
        {
            Person person = Get(id);
            if(person != null)
            {
                if (person.ContactInfo.Any(s=>s.Type == contact.Type))
                {
                    foreach (var item in person.ContactInfo)
                    {
                        if (item.Type == contact.Type)
                        {
                            item.Content = contact.Content;
                        }
                    }
                }
                else
                {
                    person.ContactInfo.Add(contact);
                }

                Update(person);
                
            }
            return person;
        }

        public Person RemoveContact(string id, Contact contact)
        {
            Person person = Get(id);
            if (person != null)
            {
                person.ContactInfo = person.ContactInfo.Where(s => s.Content != contact.Content && s.Type != contact.Type).ToList();
            }

            Update(person);

            return person;
        }

    }
}
