using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string SkillName { get; set; }

        public virtual ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
