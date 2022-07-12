using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl
{
    public class ZonesRepository:IZonesRepository
    {
        private readonly MetersDbContext _context;

        public ZonesRepository(MetersDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Zones> FindAll()
        {
            return _context.Zones
                .Include(z => z.meters);
        }


        public IEnumerable<Zones> FindAllByName(string name)
        {
            return _context.Zones.Where(z=>z.name ==name)
                .Include(z => z.meters);
        }
    }
}
