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
    public class EMI_EventsRepository : IEventRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public EMI_EventsRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        
        public async Task<bool> AddEvent(Event e_event)
        {
            await _selahDbContext.Events.AddAsync(e_event);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<Event> GetEvent(int eventId)
        {
            return await _selahDbContext.Events.FindAsync(eventId);
        }

        public async Task<bool> DeleteEventAsync(Event e_event)
        {
            _selahDbContext.Remove(e_event);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> UpdateEvent(Event e_event)
        {
            _selahDbContext.Update<Event>(e_event);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public List<Event> GetEvents()
        {
            return _selahDbContext.Events.OrderByDescending(x => x.CreatedAt).ToList();

        }
    }
}
