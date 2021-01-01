using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ContentSubItem
    {
        [Key]
        public int Id { get; set; }

        public string SubItemContent { get; set; }
        [JsonIgnore]
        public ContentItem ExperienceItem { get; set; }
    }
}
