using Microsoft.EntityFrameworkCore;
namespace Neag_Stefan_Lab2.Data
{
    public class Neag_Stefan_Lab2Context(DbContextOptions<Neag_Stefan_Lab2Context> options) : DbContext(options)
    {
        public DbSet<Neag_Stefan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Neag_Stefan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Neag_Stefan_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Neag_Stefan_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Neag_Stefan_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;
    }
}