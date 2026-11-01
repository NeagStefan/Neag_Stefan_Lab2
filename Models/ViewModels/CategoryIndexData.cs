using System.Collections.Generic;
using Neag_Stefan_Lab2.Models;

namespace Neag_Stefan_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}