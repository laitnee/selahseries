using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface IVolunteerRepository
    {
        Task<bool> AddVolunteer(Volunteer volunteer);
        List<Volunteer> GetVolunteers();
        Task<Volunteer> GetVolunteer(int volunteerId);
        Task<bool> DeleteVolunteerAsync(Volunteer volunteer);
        Task<bool> UpdateVolunteer(Volunteer volunteer);
    }
}
