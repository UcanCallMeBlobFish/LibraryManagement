using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public CategoryEnum CategoryName { get; set; }

        //nav
        public ICollection<Book> Books { get; set; }
    }

}
