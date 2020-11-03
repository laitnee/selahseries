using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Services
{
    public interface IEmailService
    {
        Task SendEmail(string subject, string message);
        void SendSubscriptionMail(List<String> emailSubscribers, string title, string Message, int postId, string imagePath, string mailType);
        Task SendEmailTo(string subject, string message, string toEmail);
    }
}
