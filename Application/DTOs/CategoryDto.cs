using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoryCreateDto
    {
        public CategoryEnum CategoryName { get; set; }
    }

    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public CategoryEnum CategoryName { get; set; }
    }

    public class CategoryDeleteDto
    {
        public int Id { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public CategoryEnum CategoryName { get; set; }
        public ICollection<int> BookIds { get; set; }
    }

}
