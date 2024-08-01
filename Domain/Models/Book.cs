using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        //Navigation Properties

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<BookAuthor> bookAuthors { get; set; }
        public ICollection<BookOnShelves> bookOnShelves { get; set; }

    }

}
