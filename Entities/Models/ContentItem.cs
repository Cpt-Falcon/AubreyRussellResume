using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContentItem
    {
        [Key]
        public int Id { get; set; }

        public string ExperienceItemContent { get; set; }

        public ICollection<ContentSubItem> ExperienceSubItems { get; set; } = new List<ContentSubItem>();

    }
}
