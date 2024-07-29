using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        
        //Navigation Properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<BookAuthor> bookAuthors { get; set; }
        public ICollection<BookOnShelves> bookOnShelves { get; set; }

    }

}
