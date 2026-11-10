using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neag_Stefan_Lab2.Models;
using Neag_Stefan_Lab2.Data;

namespace Neag_Stefan_Lab2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Neag_Stefan_Lab2Context _context;
    public DetailsModel(Neag_Stefan_Lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
    .Include(b => b.Book)
        .ThenInclude(b => b.Author)
    .Include(b => b.Member)
    .FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        else
        {
            Borrowing = borrowing;
        }

        return Page();
    }
}
