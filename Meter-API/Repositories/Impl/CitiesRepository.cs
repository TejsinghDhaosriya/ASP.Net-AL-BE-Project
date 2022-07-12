using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl;

public class CitiesRepository : ICitiesRepository

{
    private readonly MetersDbContext _context;

    public CitiesRepository(MetersDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cities> FindAll()
    {
        return _context.Cities
            .Include(c => c.facilities)
            .ThenInclude(f => f.buildings)
            .ThenInclude(b => b.floors)
            .ThenInclude(f => f.zones)
            .ThenInclude(z => z.meters);
    }

    public IEnumerable<Cities> FindAllByName(string name)
    {
        return _context.Cities.Where(c=>c.name == name)
            .Include(c => c.facilities)
            .ThenInclude(f => f.buildings)
            .ThenInclude(b => b.floors)
            .ThenInclude(f => f.zones)
            .ThenInclude(z => z.meters);
    }
}
