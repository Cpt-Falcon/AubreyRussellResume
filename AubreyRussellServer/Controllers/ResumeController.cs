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
        private readonly ILogger<ResumeController> _logger;

        public ResumeController(ILogger<ResumeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/GetCodeSnippets")]
        public IEnumerable<CodeSnippet> GetCodeSnippets()
        {
            List<CodeSnippet> codeSnippets = new List<CodeSnippet>();

            codeSnippets.Add(new CodeSnippet());
            codeSnippets.Add(new CodeSnippet());
            codeSnippets[0].Resume = new Resume();
            codeSnippets[0].Resume.Person = new Person();
            codeSnippets[0].Resume.Person.EmailAddress = "test@test.com";
            return codeSnippets;
        }
    }
}
