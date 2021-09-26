using Setur.Entity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setur.Entity.Models
{
    public class Contact
    {
        public InformationType Type { get; set; }
        public string Content { get; set; }
    }
}
