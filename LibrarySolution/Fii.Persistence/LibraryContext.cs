using Fii.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fii.Persistence
{
    internal sealed class LibraryContext : DbContext
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=True;";
        public DbSet<Author> Authors { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConnectionString);
        }
    }
}
