using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Checkout
    {
        public int CheckoutId { get; set; }
        public bool IsReturned { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        //Nav
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookOnShelvesId { get; set; }
        public BookOnShelves BookOnShelves { get; set; }
    }

}
