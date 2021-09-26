using Setur.Business.Models;
using Setur.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Business.Services
{
    public interface IPersonService
    {
        List<Person> Get();
        Person Get(string id);
        Person Create(Person Person);
        void Update(Person person);
        void Remove(Person PersonIn);
        void Remove(string id);
        List<LocationReport> Report();
        Person AddContact(string id, Contact contact);
        Person RemoveContact(string id, Contact contact);
    }
}
