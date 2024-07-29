using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CheckoutCreateDto
    {
        public bool IsReturned { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerId { get; set; }
        public int BookOnShelvesId { get; set; }
    }

    public class CheckoutUpdateDto
    {
        public int Id { get; set; }
        public bool IsReturned { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerId { get; set; }
        public int BookOnShelvesId { get; set; }
    }

    public class CheckoutDeleteDto
    {
        public int Id { get; set; }
    }

    public class CheckoutDto
    {
        public int Id { get; set; }
        public bool IsReturned { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerId { get; set; }
        public int BookOnShelvesId { get; set; }
    }

}
