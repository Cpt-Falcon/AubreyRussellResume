using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public string InterestName { get; set; }

        public virtual ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
