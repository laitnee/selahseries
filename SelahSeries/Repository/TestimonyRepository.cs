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
    public class TestimonyRepository : ITestimonyRepository
    {
        private SelahSeriesDataContext _selahDbContext;

        public TestimonyRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }

        public async Task<bool> AddTestimony(Testimonial testimony)
        {
            await _selahDbContext.AddAsync(testimony);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeleteTestimonyAsync(Testimonial testimony)
        {
            _selahDbContext.Remove(testimony);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public List<Testimonial> GetTestimonies()
        {
            return _selahDbContext.Testimonials.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public async Task<Testimonial> GetTestimony(int testimonyId)
        {
            return await _selahDbContext.Testimonials.FindAsync(testimonyId);
        }

        public async Task<bool> UpdateTestimony(Testimonial testimony)
        {
            _selahDbContext.Update<Testimonial>(testimony);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
    }
}
