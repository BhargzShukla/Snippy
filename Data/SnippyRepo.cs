using System;
using System.Collections.Generic;
using System.Linq;
using Snippy.Models;

namespace Snippy.Data
{
    public class SnippyRepo : ISnippyRepo
    {
        private readonly SnippyContext _context;

        public SnippyRepo(SnippyContext context)
        {
            _context = context;
        }

        public void CreateSnippet(Snippet snippet)
        {
            if (snippet == null)
            {
                throw new ArgumentNullException(nameof(snippet));
            }
            _context.Snippets.Add(snippet);
        }

        public void DeleteSnippet(Snippet snippet)
        {
            if (snippet == null)
            {
                throw new ArgumentNullException(nameof(snippet));
            }
            _context.Snippets.Remove(snippet);
        }

        public IEnumerable<Snippet> GetAllCommands()
        {
            return _context.Snippets.ToList();
        }

        public Snippet GetSnippetById(int id)
        {
            return _context.Snippets.FirstOrDefault(snip => snip.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSnippet(Snippet snippet)
        {
            // Nothing.
        }
    }
}