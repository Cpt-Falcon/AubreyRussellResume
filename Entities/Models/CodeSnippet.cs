using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CodeSnippet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Resume")]
        public int ResumeId { get; set; }

        public string Name { get; set; }

        public string RepoLink { get; set; }

        public string Snippet { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}
