using Microsoft.EntityFrameworkCore;
using Tatesoft.WebAPI.Entities;

namespace Tatesoft.WebAPI.Context
{
    public class TatesoftBackendDbContext : DbContext
    {
        public TatesoftBackendDbContext(DbContextOptions<TatesoftBackendDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ContentArea> ContentAreas { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Revision> Revision { get; set; }

    }
}
