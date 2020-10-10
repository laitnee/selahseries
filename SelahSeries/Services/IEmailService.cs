using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Services
{
    public interface IEmailService
    {
        Task SendEmail(string subject, string message);
        Task SendEmailTo(string subject, string message, string toEmail);
    }
}
