using System.Collections.Generic;
using System.Security;
using Snippy.Models;

namespace Snippy.Data
{
    public class MockSnippyRepo : ISnippyRepo
    {
        public void CreateSnippet(Snippet snippet)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSnippet(Snippet snippet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Snippet> GetAllCommands()
        {
            var snippets = new List<Snippet>
            {
               new Snippet{Id=0, Code="ipdb", Expansion="import pdb; pdb.set_trace()", Description="Setup pdb and call set_trace()", Platform="Python"},
                new Snippet{Id=1, Code="sout", Expansion="System.out.println();", Description="Print a line to console", Platform="Java"},
                new Snippet{Id=2, Code="error", Expansion="console.error();", Description="Print error message to console", Platform="JavaScript"}
            };
            return snippets;
        }

        public Snippet GetSnippetById(int id)
        {
            return new Snippet { Id = 0, Code = "ipdb", Expansion = "import pdb; pdb.set_trace()", Description = "Setup pdb and call set_trace()", Platform = "Python" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSnippet(Snippet snippet)
        {
            throw new System.NotImplementedException();
        }
    }
}