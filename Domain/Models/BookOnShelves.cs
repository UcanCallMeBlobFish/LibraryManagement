using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Domain.Models
{
    public class BookOnShelves
    {
        public int Id { get; set; }
        public string Edition { get; set; }
        public ConditionEnum Condition { get; set; }
        public string UserNote { get; set; }


        //Nav
        public int BookId { get; set; }
        public int EditorId { get; set; }

        public Book Book { get; set; }
        public Editor Editor { get; set; }
    }

}
