using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories
{
    public class MetersDbContext : DbContext
    {
        public MetersDbContext(DbContextOptions<MetersDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Cities> Cities { get; set; }
        public DbSet<Models.Buildings> Buildings { get; set; }
        public DbSet<Models.Facilities> Facilities { get; set; }
        public DbSet<Models.Floors> Floors { get; set; }
        public DbSet<Models.Meters> Meters { get; set; }
        public DbSet<Models.Zones> Zones { get; set; }
    }
}
