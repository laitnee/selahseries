using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly SelahSeriesDataContext selahDbContext;

        public VolunteerRepository(SelahSeriesDataContext selahDbContext)
        {
            this.selahDbContext = selahDbContext;
        }
        public async Task<bool> AddVolunteer(Volunteer volunteer)
        {
            await selahDbContext.AddAsync(volunteer);
            return Convert.ToBoolean(await selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeleteVolunteerAsync(Volunteer volunteer)
        {
            selahDbContext.Remove(volunteer);
            return Convert.ToBoolean(await selahDbContext.SaveChangesAsync());
        }

        public async Task<Volunteer> GetVolunteer(int volunteerId)
        {
            return await selahDbContext.Volunteers.FindAsync(volunteerId);
        }

        public List<Volunteer> GetVolunteers()
        {
            return selahDbContext.Volunteers.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public async Task<bool> UpdateVolunteer(Volunteer volunteer)
        {
            selahDbContext.Update<Volunteer>(volunteer);
            return Convert.ToBoolean(await selahDbContext.SaveChangesAsync());
        }
    }
}
