using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerCreateDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }

    public class CustomerUpdateDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }

    public class CustomerDeleteDto
    {
        public string Username { get; set; }
    }

    public class CustomerDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public ICollection<int> CheckoutIds { get; set; }
        public ICollection<int> AlertIds { get; set; }
    }

}
