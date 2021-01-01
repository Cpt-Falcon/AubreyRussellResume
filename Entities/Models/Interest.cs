using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public string InterestName { get; set; }

        [JsonIgnore]
        public ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
