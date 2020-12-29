using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CodeSnippet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RepoLink { get; set; }

        public Resume Resume { get; set; }
    }
}
