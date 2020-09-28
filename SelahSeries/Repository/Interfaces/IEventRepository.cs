using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface IEventRepository
    {
        Task<bool> AddEvent(Event emi_event);
        List<Event> GetEvents();
        Task<Event> GetEvent(int eventId);
        Task<bool> DeleteEventAsync(Event emi_event);
        Task<bool> UpdateEvent(Event emi_event);
    }
}
