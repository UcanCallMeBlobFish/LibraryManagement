using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Editor : BaseEntity
    {

        public string EditorName { get; set; }

        public ICollection<BookOnShelves> bookOnShelves { get; set; }
    }

}
