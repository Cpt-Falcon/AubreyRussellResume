using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Resume
    {
        public int Id { get; set; }

        public virtual ICollection<CodeSnippet> CodeSnippets { get; set; } = new List<CodeSnippet>();

        public virtual Person Person { get; set; }
    }
}
