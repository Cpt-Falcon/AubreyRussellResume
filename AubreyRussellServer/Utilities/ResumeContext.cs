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

        public async Task<Resume> AddNewResume(Person me)
        {
            Person checkExisting = await this.Persons.FirstOrDefaultAsync(x => x.EmailAddress == me.EmailAddress);
            me = checkExisting == null ? me : checkExisting;
            Resume newResume = new Resume()
            {
                Person = me
            };

            await this.Resumes.AddAsync(newResume);
            await this.SaveChangesAsync();
            return newResume;
        }

        public async Task AddProfessionalHistoryToResume(string personEmail, ExperienceHistory experienceHistory)
        {
            Resume toUpdate = await this.GetCompleteResumeByPersonEmail(personEmail, false);
            experienceHistory.Employer = await this.AddGetEmployer(experienceHistory.Employer);
            this.Employers.Attach(experienceHistory.Employer);
            toUpdate.ProfessionalExperienceHistories.Add(experienceHistory);
            await this.SaveChangesAsync();
        }

        public async Task AddCodeSnippetToResume(string personEmail, CodeSnippet codeSnippet)
        {
            Resume toUpdate = await this.GetCompleteResumeByPersonEmail(personEmail, false);
            toUpdate.CodeSnippets.Add(codeSnippet);
            await this.SaveChangesAsync();
        }

        public async Task AddEducationToResume(string personEmail, EducationHistory education)
        {
            Resume toUpdate = await this.GetCompleteResumeByPersonEmail(personEmail, false);
            toUpdate.EducationHistory = education;
            await this.AddGetSchool(education.School);
            this.Schools.Attach(education.School);
            await this.SaveChangesAsync();
        }

        public async Task AddProjectToResume(string personEmail, ProjectsHistory project)
        {
            Resume toUpdate = await this.GetCompleteResumeByPersonEmail(personEmail, false);
            toUpdate.ProjectsHistory = project;
            await this.SaveChangesAsync();
        }

        public async Task<School> AddGetSchool(School school)
        {
            School returnSchool;
            if ((returnSchool = await this.Schools.FirstOrDefaultAsync(x => x.SchoolName == school.SchoolName && x.SchoolLocation == school.SchoolLocation)) == null)
            {
                school.Id = 0;
                await this.Schools.AddAsync(school);
                await this.SaveChangesAsync();
                returnSchool = school;
            }

            return returnSchool;
        }

        public async Task<Employer> AddGetEmployer(Employer employer)
        {
            Employer returnEmployer;
            if ((returnEmployer = await this.Employers.FirstOrDefaultAsync(x => x.Name == employer.Name)) == null)
            {
                employer.Id = 0;
                await this.Employers.AddAsync(employer);
                await this.SaveChangesAsync();
                returnEmployer = employer;
            }

            return returnEmployer;
        }

        public async Task<Resume> GetCompleteResumeByPersonEmail(string personEmail, bool includeAll = true)
        {
            var foundResume = this.Resumes.Include(x => x.Person);

            // Include items seperately to avoid cartesian explosion problem. Need to generate list each time to ensure things are properly included. 
            if (includeAll)
            {
                _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Interests).ToListAsync();
                _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Languages).ToListAsync();
                _ = await foundResume.Include(x => x.Person).ThenInclude(x => x.Skills).ToListAsync();
                _ = await foundResume.Include(x => x.CodeSnippets).ToListAsync();
                _ = await foundResume.Include(x => x.ProfessionalExperienceHistories).ThenInclude(x => x.Employer).ToListAsync();
                _ = await foundResume.Include(x => x.ProfessionalExperienceHistories).ThenInclude(x => x.ExperienceItems).ToListAsync();
                _ = await foundResume.Include(x => x.EducationHistory).ThenInclude(x => x.School).ToListAsync();
                _ = await foundResume.Include(x => x.EducationHistory).ThenInclude(x => x.ExperienceItems).ToListAsync();
                _ = await foundResume.Include(x => x.ProjectsHistory).ThenInclude(x => x.ExperienceItems).ToListAsync(); 
            }

            return await foundResume.FirstOrDefaultAsync(x => x.Person.EmailAddress == personEmail);
        }

    }
}
