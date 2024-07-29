using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AlertCreateDto
    {
        public string UserTo { get; set; }
        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

    public class AlertUpdateDto
    {
        public int Id { get; set; }
        public string UserTo { get; set; }
        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

    public class AlertDeleteDto
    {
        public int Id { get; set; }
    }

    public class AlertDto
    {
        public int Id { get; set; }
        public string UserTo { get; set; }
        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

}
