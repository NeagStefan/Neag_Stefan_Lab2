using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neag_Stefan_Lab2.Data;
using Neag_Stefan_Lab2.Models;

namespace Neag_Stefan_Lab2.Pages.BookPages
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Neag_Stefan_Lab2Context _context;

        public CreateModel(Neag_Stefan_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "LastName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();

            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            // Creăm o nouă instanță și preluăm direct proprietățile din obiectul legat
            var newBook = new Book
            {
                Title = Book.Title,
                Price = Book.Price,
                PublishingDate = Book.PublishingDate,
                AuthorID = Book.AuthorID,
                PublisherID = Book.PublisherID,
                BookCategories = new List<BookCategory>()
            };

            // Adăugăm categoriile selectate din checkbox-uri
            if (selectedCategories != null)
            {
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}