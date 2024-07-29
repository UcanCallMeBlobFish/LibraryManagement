using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;
using Domain.Models.Enums;

namespace Domain.Models
{
    public class Category : BaseEntity
    {

     
        public CategoryEnum CategoryName { get; set; }

        //nav
        public ICollection<Book> Books { get; set; }
    }

}
