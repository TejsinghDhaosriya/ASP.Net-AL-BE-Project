using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Cities
{
    public class CitiesDbContext:DbContext
    {
        public CitiesDbContext(DbContextOptions<CitiesDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Cities> Cities { get; set; }
    }
}
