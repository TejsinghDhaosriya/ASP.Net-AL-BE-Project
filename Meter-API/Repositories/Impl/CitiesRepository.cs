﻿using Meter_API.Domain.requests;
using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Meter_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl;

public class CitiesRepository : ICitiesRepository

{
    private readonly MetersDbContext _context;

    public CitiesRepository(MetersDbContext context)
    {
        _context = context;
    }

    public List<Cities> FindAll(QueryParameters qp)
    {
        IQueryable<Cities> query =  _context.Cities
            .Include(c => c.facilities)
            .ThenInclude(f => f.buildings)
            .ThenInclude(b => b.floors)
            .ThenInclude(f => f.zones)
            .ThenInclude(z => z.meters);
        if (!ApiUtils.IsEmpty(qp.name))
            query = query.Where(c => c.name == qp.name);
        if (!ApiUtils.IsEmpty(qp.startDate))
            query = query.Where(c => c.createdDate >= DateTime.Parse(qp.startDate));
        if (!ApiUtils.IsEmpty(qp.endDate))
            query = query.Where(c => c.createdDate <= DateTime.Parse(qp.endDate));

        return query.ToList();
    }

}
