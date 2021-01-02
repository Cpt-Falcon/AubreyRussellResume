using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ProjectsHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Resume")]
        public int ResumeId { get; set; }

        public ICollection<ContentItem> ExperienceItems { get; set; } = new List<ContentItem>();

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}
