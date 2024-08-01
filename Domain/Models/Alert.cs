﻿using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Alert : BaseEntity
    {


        //fk
        public string CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }



        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

}
