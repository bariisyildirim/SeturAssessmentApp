using Setur.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Data.Repositories
{
    public interface IPersonRepository
    {
        List<Person> Get();
        Person Get(string id);
        Person Create(Person Person);
        void Update(Person person);
        void Remove(Person PersonIn);
        void Remove(string id);
    }
}
