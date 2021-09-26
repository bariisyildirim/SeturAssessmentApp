using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Setur.APIApp.Models
{
    public class LocationReport
    {
        public string LocationName { get; set; }
        public int LocationCount { get; set; }
        public int PeopleCount { get; set; }
        public int PeoplePhoneNumberCount { get; set; }
    }
}
