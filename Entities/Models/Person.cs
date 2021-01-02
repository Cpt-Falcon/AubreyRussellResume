using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Resume")]
        public int ResumeId { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }

        public ICollection<Language> Languages { get; set; } = new List<Language>();

        public ICollection<Skill> Skills { get; set; } = new List<Skill>();

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
    }
}
