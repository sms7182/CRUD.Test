using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Domain;

namespace Car.Data.Configuration
{
    public class CarDbContext:DbContext
    {
        public DbSet<Domain.Car> Cars => Set<Domain.Car>();
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Car>().HasKey(c => c.Id);
         
        }
        
    }
}
