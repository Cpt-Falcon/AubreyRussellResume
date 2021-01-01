using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubreyRussellServer.Utilities
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }

        public DbSet<CodeSnippet> CodeSnippets { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<ContentSubItem> ContentSubItems { get; set; }
        public DbSet<EducationHistory> EducationHistorys { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<ExperienceHistory> ExperienceHistorys { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProjectsHistory> ProjectsHistorys { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public async Task AddResume(Resume resume)
        {
            if (!(await Resumes.AnyAsync(x => x.Id == resume.Id)))
            {
                await this.Resumes.AddAsync(resume);
                await this.SaveChangesAsync();
            }
        }

        //public async Task AddExperienceHistory(ExperienceHistory experienceHist)
        //{

        //}

        public async Task<Resume> GetCompleteResumeByPersonName(string personFullName)
        {
            var foundResume = this.Resumes.Include(x => x.Person);

            // Include items seperately to avoid cartesian explosion problem.
            _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Interests).ToListAsync();
            _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Languages).ToListAsync();
            _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Skills).ToListAsync();
            _ = await foundResume.Include(x => x.CodeSnippets).ToListAsync();
            _ = await foundResume.Include(x => x.ProfessionalExperienceHistories).ThenInclude(x => x.Employer).ToListAsync();
            _ = await foundResume.Include(x => x.ProfessionalExperienceHistories).ThenInclude(x => x.ExperienceItems).ToListAsync();
            _ = await foundResume.Include(x => x.EducationHistory).ThenInclude(x => x.School).ToListAsync();
            _ = await foundResume.Include(x => x.EducationHistory).ThenInclude(x => x.ExperienceItems).ToListAsync();
            _ = await foundResume.Include(x => x.ProjectsHistory).ThenInclude(x => x.ExperienceItems).ToListAsync();
            return await foundResume.FirstOrDefaultAsync(x => x.Person.FullName == personFullName);
        }
    }
}
