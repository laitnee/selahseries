using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> AddNotification(Notification notification);
        Task<Notification> MarkNotificationAsRead(int notificationID);
        Task<Notification> GetNotificationById(int notificationId);
        Task<PaginatedList<Notification>> GetNotificationsByPage(PaginationParam pageParam);

        Task<int> GetUnreadNotificationCount ();
    }
}
