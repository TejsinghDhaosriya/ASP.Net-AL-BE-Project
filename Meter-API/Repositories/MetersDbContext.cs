using Meter_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories
{
    public class MetersDbContext : DbContext
    {
        public MetersDbContext(DbContextOptions<MetersDbContext> options) : base(options)
        {
        }

        public DbSet<Cities?> Cities { get; set; }
        public DbSet<Buildings?> Buildings { get; set; }
        public DbSet<Facilities?> Facilities { get; set; }
        public DbSet<Floors?> Floors { get; set; }
        public DbSet<Meters?> Meters { get; set; }
        public DbSet<Zones?> Zones { get; set; }
    }
}
