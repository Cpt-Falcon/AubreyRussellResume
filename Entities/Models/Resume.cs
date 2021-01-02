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

        public void CopyContent(Resume existingResume)
        {
            this.ProfessionalExperienceHistories = existingResume.ProfessionalExperienceHistories;
            this.EducationHistory = existingResume.EducationHistory;
            this.ProjectsHistory = existingResume.ProjectsHistory;
            this.CodeSnippets = existingResume.CodeSnippets;
            this.Person = existingResume.Person;
        }
    }
}
