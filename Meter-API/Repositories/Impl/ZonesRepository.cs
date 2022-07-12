using Meter_API.Domain.requests;
using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Meter_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl;

public class ZonesRepository : IZonesRepository
{
    private readonly MetersDbContext _context;

    public ZonesRepository(MetersDbContext context)
    {
        _context = context;
    }


    public List<Zones> FindAll(QueryParameters qp)
    {
        IQueryable<Zones> query = _context.Zones
            .Include(z => z.meters);
        if (!ApiUtils.IsEmpty(qp.name))
            query = query.Where(c => c.name == qp.name);
        if (!ApiUtils.IsEmpty(qp.startDate))
            query = query.Where(c => c.createdDate >= DateTime.Parse(qp.startDate));
        if (!ApiUtils.IsEmpty(qp.endDate))
            query = query.Where(c => c.createdDate <= DateTime.Parse(qp.endDate));
        return query.ToList();
    }
}