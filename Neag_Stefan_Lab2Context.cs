using Microsoft.EntityFrameworkCore;

public class Neag_Stefan_Lab2Context(DbContextOptions<Neag_Stefan_Lab2Context> options) : DbContext(options)
{
    public DbSet<Neag_Stefan_Lab2.Models.Book> Book { get; set; } = default!;
}
