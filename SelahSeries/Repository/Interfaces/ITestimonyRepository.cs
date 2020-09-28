using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface ITestimonyRepository
    {
        Task<bool> AddTestimony(Testimonial testimony);
        List<Testimonial> GetTestimonies();
        Task<Testimonial> GetTestimony(int testimonyId);
        Task<bool> DeleteTestimonyAsync(Testimonial testimony);
        Task<bool> UpdateTestimony(Testimonial testimony);
    }
}
