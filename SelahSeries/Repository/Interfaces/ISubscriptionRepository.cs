using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public interface ISubscriptionRepository
    {
        Task<List<EmailSubscription>> GetPostSuscribers();
        Task AddPostSuscribers(EmailSubscription emailSuscriber);
        Task UnSuscriberPost(string emailSuscriber);
    }
}
