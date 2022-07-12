using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl
{
    public class FloorsRepository:IFloorsRepository
    {
        private readonly MetersDbContext _context;

        public FloorsRepository(MetersDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Floors> FindAll()
        {
            return _context.Floors
                .Include(f => f.zones)
                .ThenInclude(z => z.meters);
        }


        public IEnumerable<Floors> FindAllByName(string name)
        {
            return _context.Floors.Where(f=>f.name == name)
                .Include(f => f.zones)
                .ThenInclude(z => z.meters);
        }
    }
}
