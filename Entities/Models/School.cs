using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        public string SchoolName { get; set; }

        public string SchoolLocation { get; set; }

        [JsonIgnore]
        public ICollection<EducationHistory> EducationHistory { get; set; } = new List<EducationHistory>();
    }
}
