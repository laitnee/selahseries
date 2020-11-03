using Microsoft.EntityFrameworkCore;
using SelahSeries.Data;
using SelahSeries.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public SubscriptionRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;

        }

        public async Task<List<EmailSubscription>> GetPostSuscribers()
        {
            return await _selahDbContext.EmailSubscriptions.ToListAsync();
        }
        public async Task AddPostSuscribers(EmailSubscription emailSuscriber)
        {
            await _selahDbContext.AddAsync(emailSuscriber);
            await _selahDbContext.SaveChangesAsync();
        }
        public async Task UnSuscriberPost(string email)
        {
            var subscription = await _selahDbContext.EmailSubscriptions.Where(sub => sub.SubscriberEmail == email).FirstOrDefaultAsync();
            if (subscription == null) return;
            _selahDbContext.EmailSubscriptions.Remove(subscription);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await _selahDbContext.SaveChangesAsync();
        }

    }
}
