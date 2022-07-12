using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl
{
    public class FacilitiesRepository:IFacilitiesRepository
    {
        private readonly MetersDbContext _context;

        public FacilitiesRepository(MetersDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Facilities> FindAll()
        {
            return _context.Facilities
                .Include(f => f.buildings)
                .ThenInclude(b => b.floors)
                .ThenInclude(f => f.zones)
                .ThenInclude(z => z.meters);
        }


        public IEnumerable<Facilities> FindAllByName(string name)
        {
            return _context.Facilities.Where(f=>f.name == name)
                .Include(f => f.buildings)
                .ThenInclude(b => b.floors)
                .ThenInclude(f => f.zones)
                .ThenInclude(z => z.meters);
        }
    }
}
