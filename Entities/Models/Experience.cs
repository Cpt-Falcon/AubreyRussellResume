using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Experience
    {
        public int Id { get; set; }



        public Employer Employer { get; set; }

        public virtual ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
