using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neag_Stefan_Lab2.Models;

namespace Neag_Stefan_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Neag_Stefan_Lab2Context _context;

    public IndexModel(Neag_Stefan_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
      .Include(b => b.Publisher)
      .Include(b => b.Author) // <- Adaugă linia asta
      .ToListAsync();
    }
}
