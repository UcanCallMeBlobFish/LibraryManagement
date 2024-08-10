using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookOnShelvesCreateDto
    {
        public string Edition { get; set; }
        public ConditionEnum Condition { get; set; }
        public string UserNote { get; set; }
        public int BookId { get; set; }
        public int EditorId { get; set; }
    }

    public class BookOnShelvesUpdateDto
    {
        public int Id { get; set; }
        public string Edition { get; set; }
        public ConditionEnum Condition { get; set; }
        public string UserNote { get; set; }
        public int BookId { get; set; }
        public int EditorId { get; set; }
    }

    public class BookOnShelvesDeleteDto
    {
        public int Id { get; set; }
    }

    public class BookOnShelvesDto
    {
        public int Id { get; set; }
        public string Edition { get; set; }
        public ConditionEnum Condition { get; set; }
        public string UserNote { get; set; }
        public int BookId { get; set; }
        public int EditorId { get; set; }
        public ICollection<int> CheckoutIds { get; set; }

        public bool IsAvailable { get; set; } = true;

    }

}
