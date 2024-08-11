using Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Email
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
