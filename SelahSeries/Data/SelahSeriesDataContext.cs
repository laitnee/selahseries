using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Data
{
    public class SelahSeriesDataContext : DbContext
    {
        private IConfiguration _configuration;
        public SelahSeriesDataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HardBook> HardBooks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SoftBook> SoftBooks{ get; set; }


        //public DbSet<HardBookCategory> HardBookCategories { get; set; }
        //public DbSet<PostCategory> PostCategories { get; set; }
        //public DbSet<SoftBookCategory> SoftBookCategories{ get; set; }

    }
}
