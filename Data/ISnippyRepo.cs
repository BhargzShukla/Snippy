using System.Collections.Generic;
using Snippy.Models;

namespace Snippy.Data
{
    public interface ISnippyRepo
    {
        bool SaveChanges();
        IEnumerable<Snippet> GetAllCommands();
        Snippet GetSnippetById(int id);
        void CreateSnippet(Snippet snippet);
        void UpdateSnippet(Snippet snippet);
        void DeleteSnippet(Snippet snippet);
    }
}