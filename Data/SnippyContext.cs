using Microsoft.EntityFrameworkCore;
using Snippy.Models;

namespace Snippy.Data
{
    public class SnippyContext : DbContext
    {
        public SnippyContext(DbContextOptions<SnippyContext> options) : base(options)
        {}

        public DbSet<Snippet> Snippets { get; set; }
    }
}