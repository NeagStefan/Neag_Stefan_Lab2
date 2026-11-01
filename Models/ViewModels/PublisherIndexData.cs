using System.Collections.Generic;
using Neag_Stefan_Lab2.Models;

namespace Neag_Stefan_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}