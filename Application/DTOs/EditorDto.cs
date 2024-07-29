using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EditorCreateDto
    {
        public string EditorName { get; set; }
    }

    public class EditorUpdateDto
    {
        public int Id { get; set; }
        public string EditorName { get; set; }
    }

    public class EditorDeleteDto
    {
        public int Id { get; set; }
    }

    public class EditorDto
    {
        public int Id { get; set; }
        public string EditorName { get; set; }
        public ICollection<int> BookOnShelvesIds { get; set; }
    }

}
