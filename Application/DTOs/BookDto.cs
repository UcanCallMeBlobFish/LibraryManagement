using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }

    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }

    public class BookDeleteDto
    {
        public int Id { get; set; }
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public ICollection<int> BookAuthorIds { get; set; }
        public ICollection<int> BookOnShelvesIds { get; set; }
    }

}
