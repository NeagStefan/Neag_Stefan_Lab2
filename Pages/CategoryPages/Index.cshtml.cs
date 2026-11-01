using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neag_Stefan_Lab2.Data;
using Neag_Stefan_Lab2.Models;
using Neag_Stefan_Lab2.Models.ViewModels;

namespace Neag_Stefan_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Neag_Stefan_Lab2.Data.Neag_Stefan_Lab2Context _context;

        public IndexModel(Neag_Stefan_Lab2.Data.Neag_Stefan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
}