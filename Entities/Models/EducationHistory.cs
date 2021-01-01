using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class EducationHistory
    {
        [Key]
        [ForeignKey("Resume")]
        public int Id { get; set; }

        public ICollection<ContentItem> ExperienceItems { get; set; } = new List<ContentItem>();

        public bool Current { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }

        public School School { get; set; }
    }
}
