using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Editor
    {
        public int EditorId { get; set; }
        public string EditorName { get; set; }

        public ICollection<BookOnShelves> bookOnShelves { get; set; }
    }

}
