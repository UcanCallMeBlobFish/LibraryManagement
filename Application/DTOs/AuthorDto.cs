using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AuthorCreateDto
    {
        public string Name { get; set; }
    }

    public class AuthorUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AuthorDeleteDto
    {
        public int Id { get; set; }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> BookAuthorIds { get; set; }
    }

}
