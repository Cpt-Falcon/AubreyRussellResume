using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
