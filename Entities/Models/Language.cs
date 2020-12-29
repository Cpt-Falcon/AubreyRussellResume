using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Language
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public virtual ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
