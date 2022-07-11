using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Cities
{
    public class MetersDbContext:DbContext
    {
        public MetersDbContext(DbContextOptions<MetersDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Cities> Cities { get; set; }
    }
}
