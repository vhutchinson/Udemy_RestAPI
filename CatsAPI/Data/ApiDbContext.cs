using CatsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Cat> MyCats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                new Cat
                {
                    Id = 1,
                    Name = "Penny",
                    Type = "Torbie",
                    Age = 7,
                    Weight = 8.5
                },

                new Cat
                {
                    Id = 2,
                    Name = "Louise",
                    Type = "Potato",
                    Age = 2,
                    Weight = 16.0
                }
            );
        }
    }
}
