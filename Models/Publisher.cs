using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neag_Stefan_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}