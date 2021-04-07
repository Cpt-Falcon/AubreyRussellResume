using AubreyRussellServer.Utilities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubreyRussellServer
{
    public static class DbInitializer
    {
        public static void Initialize(ResumeContext context, SqlDBManagerService sqlDBManager)
        {
            sqlDBManager.InitDatabase().Wait();
            // Uncomment to clear database each time.
            //context.Database.EnsureDeleted();
            if (context.Database.EnsureCreated())
            {
                Person me = GeneratePerson();
                CodeSnippet codeSnippet = new CodeSnippet()
                {
                    Name = "Test Example",
                    RepoLink = "Test",
                    Snippet = "public static int Test(){\nint test = 1\n}\n"

                };

                List<CodeSnippet> codeSnippets = new List<CodeSnippet>() { codeSnippet };
                List<ExperienceHistory> experienceHistories = new List<ExperienceHistory>() { GetRaytheonHistory(), GetGoDaddyHistory() };

                Resume resume = new Resume()
                {
                    Person = me,
                    ProfessionalExperienceHistories = experienceHistories,
                    EducationHistory = GetEducationHistory(),
                    ProjectsHistory = GetProjectsHistory(),
                    CodeSnippets = codeSnippets
                };

                context.AddResume(resume).Wait();
            }
        }

        private static ProjectsHistory GetProjectsHistory()
        {
            List<ContentSubItem> contentSubItems = new List<ContentSubItem>();
            List<ContentItem> contentItems = new List<ContentItem>();

            ContentSubItem contentSubItem1 = new ContentSubItem()
            {
                SubItemContent = "Using Keras, Tensorflow and the Vanguard Stock API to analyze and predict stock market and cryptocurrency trends."
            };

            contentSubItems.Add(contentSubItem1);

            ContentItem contentItem = new ContentItem()
            {
                ExperienceItemContent = "C# Stock Analysis Program",
                ExperienceSubItems = contentSubItems
            };

            contentItems.Add(contentItem);

            ProjectsHistory ph = new ProjectsHistory()
            {
                ExperienceItems = contentItems
            };

            return ph;
        }

        private static EducationHistory GetEducationHistory()
        {
            List<ContentSubItem> contentSubItems = new List<ContentSubItem>();
            List<ContentItem> contentItems = new List<ContentItem>();

            ContentSubItem contentSubItem1 = new ContentSubItem()
            {
                SubItemContent = "Bachelor of Science in Computer Engineering"
            };

            ContentSubItem contentSubItem2 = new ContentSubItem()
            {
                SubItemContent = "GPA: 3.1"
            };

            contentSubItems.Add(contentSubItem1);
            contentSubItems.Add(contentSubItem2);

            ContentItem contentItem = new ContentItem()
            {
                ExperienceItemContent = "Cal Poly San Luis Obispo",
                ExperienceSubItems = contentSubItems
            };

            contentItems.Add(contentItem);

            School calPoly = new School()
            {
                SchoolName = "Cal Poly",
                SchoolLocation = "San Luis Obispo"
            };

            EducationHistory eh = new EducationHistory()
            {
                School = calPoly,
                ExperienceItems = contentItems
            };

            return eh;
        }

        private static ExperienceHistory GetGoDaddyHistory()
        {
            Employer godaddyEmployer = new Employer()
            {
                Name = "Go Daddy"
            };

            List<ContentSubItem> contentSubItems = new List<ContentSubItem>();

            ContentSubItem gd1 = new ContentSubItem()
            {
                SubItemContent = @"Contributed substantially to the Office 365 team’s code base by fixing bugs and enhancing many software features."
            };

            ContentSubItem gd2 = new ContentSubItem()
            {
                SubItemContent = @"Programmed a full stack website from scratch, which required high performance sorting and searching for 100,000 entries. It used Node JS, Ember JS, and Mongo DB to load data from a slow external web API into a faster local database."
            };

            ContentSubItem gd3 = new ContentSubItem()
            {
                SubItemContent = @"Won first place in a GoDaddy sponsored hackathon and received a patent for our idea and implementation."
            };

            contentSubItems.Add(gd1);
            contentSubItems.Add(gd2);
            contentSubItems.Add(gd3);

            ContentItem overview = new ContentItem()
            {
                ExperienceItemContent = "Overview",
                ExperienceSubItems = contentSubItems
            };

            List<ContentItem> contentItems = new List<ContentItem>();
            contentItems.Add(overview);

            ExperienceHistory godaddyHistory = new ExperienceHistory()
            {
                Current = true,
                StartDate = new DateTime(2014, 1, 1, 0, 0, 0),
                EndDate = new DateTime(2015, 1, 1, 0, 0, 0),
                Employer = godaddyEmployer,
                ExperienceItems = contentItems
            };

            return godaddyHistory;
        }

        private static ExperienceHistory GetRaytheonHistory()
        {
            Employer raytheonEmployer = new Employer()
            {
                Name = "Raytheon Technologies"
            };

            ExperienceHistory raytheonHistory = new ExperienceHistory()
            {
                Current = true,
                StartDate = new DateTime(2016, 12, 1, 0, 0, 0),
                EndDate = default,
                Employer = raytheonEmployer
            };

            List<ContentSubItem> contentSubItems = new List<ContentSubItem>();

            string performanceReview = @":“Throughout the year, Aubrey has shown he exhibits the spectrum of Raytheon
values in his daily interactions, making him an especially effective team leader and ambassador for new
employees. Aubrey has provided exceptional contributions this year and has been instrumental in maturing
an important software product line.” <b>Exceptional Rating 5/5</b>";

            ContentSubItem performanceReviewItem = new ContentSubItem()
            {
                SubItemContent = performanceReview
            };

            contentSubItems.Add(performanceReviewItem);
            ContentItem performanceReviewContent = new ContentItem()
            {
                ExperienceItemContent = "Performance Review",
                ExperienceSubItems = contentSubItems
            };

            contentSubItems = new List<ContentSubItem>();

            ContentSubItem majorImpact1 = new ContentSubItem()
            {
                SubItemContent = @"Optimized algorithm efficiency, locality, memory allocations, SIMD instructions, and concurrency to drastically improve performance in a multi - threaded pipeline and secure a 10 million dollar contract."
            };

            ContentSubItem majorImpact2 = new ContentSubItem()
            {
                SubItemContent = @"Interfaced directly with important external customers and translated their requirements into complex software features necessitating object oriented and SOLID design principles."
            };

            ContentSubItem majorImpact3 = new ContentSubItem()
            {
                SubItemContent = @"Implemented proprietary software features that saved several programs hundreds of thousands of dollars and hundreds of hours of time; received a monetary achievement award as a result."
            };

            contentSubItems.Add(majorImpact1);
            contentSubItems.Add(majorImpact2);
            contentSubItems.Add(majorImpact3);

            ContentItem majorImpacts = new ContentItem()
            {
                ExperienceItemContent = "Major Impacts",
                ExperienceSubItems = contentSubItems
            };



            contentSubItems = new List<ContentSubItem>();

            ContentSubItem leadership1 = new ContentSubItem()
            {
                SubItemContent = @"Leading a successful remote software team during COVID, which fluctuates between 5 to 15 people."
            };

            ContentSubItem leadership2 = new ContentSubItem()
            {
                SubItemContent = @"Coordinated several Scrum Agile teams and mentored dozens of new hires as a recent graduate."
            };

            ContentSubItem leadership3 = new ContentSubItem()
            {
                SubItemContent = @"Acting as the software point of contact for a large number programs to accelerate their development."
            };

            contentSubItems.Add(leadership1);
            contentSubItems.Add(leadership2);
            contentSubItems.Add(leadership3);

            ContentItem leadership = new ContentItem()
            {
                ExperienceItemContent = "Leadership",
                ExperienceSubItems = contentSubItems
            };


            contentSubItems = new List<ContentSubItem>();

            ContentSubItem personalContributions1 = new ContentSubItem()
            {
                SubItemContent = @"Engineered numerous features into an existing C# code base that required parallelism, async/await,TCP/IP, distributed computing, sophisticated mathematics, advanced WPF UIs, and MVVM."
            };

            ContentSubItem personalContributions2 = new ContentSubItem()
            {
                SubItemContent = @"Architected an integrated software solution that streams real time vibration data to a single page Blazorapp by utilizing sockets, Entity Framework, and open source JavaScript solutions like ChartJs."
            };

            ContentSubItem personalContributions3 = new ContentSubItem()
            {
                SubItemContent = @"Acquired patent <b>(US 10,749,618 B1)</b> for closed loop control of RF test environments based on machinelearning."
            };

            contentSubItems.Add(personalContributions1);
            contentSubItems.Add(personalContributions2);
            contentSubItems.Add(personalContributions3);

            ContentItem personalContribution = new ContentItem()
            {
                ExperienceItemContent = "Personal Contribution",
                ExperienceSubItems = contentSubItems
            };


            contentSubItems = new List<ContentSubItem>();

            ContentSubItem workflow1 = new ContentSubItem()
            {
                SubItemContent = @"Constructed a CI/CD pipeline using Git, Jenkins, Collaborator, JIRA, and Coverity to save hundreds of hours of manual effort."
            };

            ContentSubItem workflow2 = new ContentSubItem()
            {
                SubItemContent = @"Automated a manual testing process by building thousands of unit tests, python integration tests, and emulated hardware to expand code coverage and slash the software development life-cycle duration."
            };

            contentSubItems.Add(workflow1);
            contentSubItems.Add(workflow2);

            ContentItem workflowAutomation = new ContentItem()
            {
                ExperienceItemContent = "Workflow Automation",
                ExperienceSubItems = contentSubItems
            };


            raytheonHistory.ExperienceItems.Add(performanceReviewContent);
            raytheonHistory.ExperienceItems.Add(majorImpacts);
            raytheonHistory.ExperienceItems.Add(leadership);
            raytheonHistory.ExperienceItems.Add(personalContribution);
            raytheonHistory.ExperienceItems.Add(workflowAutomation);
            return raytheonHistory;
        }

        private static Person GeneratePerson()
        {
            List<Language> languages = new List<Language>();
            string[] existingLanguages = new string[] {"C#", "C++/CLI", "C++", "C", "JavaScript", "ASP.NET Core MVC", "Blazor",
            "MySQL", "Pyton", "XAML", "HTML/CSS"};

            foreach (string lang in existingLanguages)
            {
                Language langObj = new Language()
                {
                    LanguageName = lang
                };

                languages.Add(langObj);
            }

            List<Skill> skills = new List<Skill>();
            string[] existingSkills = new string[] { "Object Oriented Design", "Design Documents", "Automated Testing", "Good GUI Design",
            "Code Analysis", "Code Review", "Scrum Agile", "Jenkins", "Git", "Github Enterprise", "Using APIs", "Building APIs",
            "Plugin Architecture", "Full Stack Development", "Entity Framework", "Xilinx SDK", "Visual Studio 2019", "Parallel Programming",
            "Concurrency,", "Multi-Threaded Debugging", "Task Based Programming", "Performance Bencmarking", "SIMD (AVX2) Vectorization", "Garbage Collection Analysis"};

            foreach (string skill in existingSkills)
            {
                Skill skillObj = new Skill()
                {
                    SkillName = skill
                };

                skills.Add(skillObj);
            }

            List<Interest> interests = new List<Interest>();
            string[] existingInterests = new string[] { "GPU Accleration", "AI/Machine Learning", "Software Defined Radios",
            "Optimization", "Big O", "Data Structures", "Algorithms", "Async/Await Pattern", "FPGAs/SOCs", "Embedded Systems",
                "IOT"};

            foreach (string interest in existingInterests)
            {
                Interest interestObj = new Interest()
                {
                    InterestName = interest
                };

                interests.Add(interestObj);
            }

            Person me = new Person()
            {
                FullName = "Aubrey Russell",
                EmailAddress = "arusse02@gmail.com",
                PhoneNumber = "949-446-5504",
                Languages = languages,
                Skills = skills,
                Interests = interests
            };

            return me;
        }
    }
}
