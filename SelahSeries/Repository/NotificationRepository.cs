using Microsoft.EntityFrameworkCore;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private SelahSeriesDataContext _selahDbContext;

        public NotificationRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;

        }
        public async Task<Notification> AddNotification(Notification notification)
        {
            if (notification == null) throw new ArgumentNullException();
            var notificationAdded = await _selahDbContext.AddAsync(notification);
            await _selahDbContext.SaveChangesAsync();
            return notificationAdded.Entity;       
        }

        public async Task<Notification> GetNotificationById(int notificationId)
        {
            if(notificationId.ToString() == null) throw new ArgumentNullException();
            return await _selahDbContext.Notifications.Where(x => x.NotificationId == notificationId).FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<Notification>> GetNotificationsByPage(PaginationParam pageParam)
        {
            
            return  await _selahDbContext.Notifications.ToPaginatedListAsync(pageParam);
        }

        public Task<int> GetUnreadNotificationCount()
        {
            return _selahDbContext.Notifications.Where(x => x.Read == false).CountAsync();
        }

        public async Task<Notification> MarkNotificationAsRead(int notificationID)
        {
            var notification = await GetNotificationById(notificationID);
            if (notification == null) throw new ArgumentNullException();
            notification.Read = true;
            _selahDbContext.Update(notification);
            await _selahDbContext.SaveChangesAsync();
            return notification;
        }
    }
}
