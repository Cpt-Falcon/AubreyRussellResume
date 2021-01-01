using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        public ICollection<ExperienceHistory> ProfessionalExperienceHistories { get; set; } = new List<ExperienceHistory>();

        public EducationHistory EducationHistory { get; set; }

        public ProjectsHistory ProjectsHistory { get; set; }

        public ICollection<CodeSnippet> CodeSnippets { get; set; } = new List<CodeSnippet>();

        public Person Person { get; set; }
    }
}
