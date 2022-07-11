using Meter_API.Domain.requests;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl;

public class MeterRepository : IMeterRepository
{
    private readonly MetersDbContext _context;

    public MeterRepository(MetersDbContext dbContext)
    {
        _context = dbContext;
    }

    public object? GetSearchDataByInformationAt(string req)
    {
        return req.ToLower() switch
        {
            "cities" => _context.Cities.Include(c => c.facilities).ThenInclude(f => f.buildings)
                .ThenInclude(b => b.floors).ThenInclude(f => f.zones).ThenInclude(z => z.meters),
            "facilities" => _context.Facilities,
            "buildings" => _context.Buildings,
            "floors" => _context.Floors,
            "zones" => _context.Zones,
            "meters" => _context.Meters,
            _ => throw new Exception("Please pass a valid informationAt")
        };
    }

    public object? GetAllSearchData()
    {
        return _context.Cities.Include(c => c.facilities).ThenInclude(f => f.buildings).ThenInclude(b => b.floors)
            .ThenInclude(f => f.zones).ThenInclude(z => z.meters);
    }

    public object? GetSearchDataByInformationAtAndNameParam(QueryParameters qp)
    {
        return qp.informationAt.ToLower() switch
        {
            "cities" => _context.Cities.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            "facilities" => _context.Facilities.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            "buildings" => _context.Buildings.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            "floors" => _context.Floors.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            "zones" => _context.Zones.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            "meters" => _context.Meters.FirstOrDefault(s => s != null && qp.name.Equals(s.name)),
            _ => throw new Exception("Please pass a valid informationAt")
        };
    }
}