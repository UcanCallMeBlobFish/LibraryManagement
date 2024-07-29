using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public string UserTo { get; set; }
        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

}
