using AubreyRussellServer.Utilities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubreyRussellServer.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<ResumeController> logger;
        private readonly ResumeContext resumeContext;

        public ResumeController(ILogger<ResumeController> logger, ResumeContext resumeContext)
        {
            this.logger = logger;
            this.resumeContext = resumeContext;
        }

        [HttpGet]
        [Route("/GetResumeContent")]
        public async Task<Resume> GetResumeContent(string resumePersonFullName)
        {
            return await resumeContext.GetCompleteResumeByPersonEmail(resumePersonFullName);
        }
    }
}
