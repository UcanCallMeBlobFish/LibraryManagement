using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Author: BaseEntity
    {
        public string Name { get; set; }
      


        public ICollection<BookAuthor> bookAuthors  { get; set; }

    }

}
