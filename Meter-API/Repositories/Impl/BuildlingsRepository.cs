﻿using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl
{
    public class BuildingsRepository:IBuildingsRepository

    {
        private readonly MetersDbContext _context;

        public BuildingsRepository(MetersDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Buildings> FindAll()
        {
            return _context.Buildings
                .Include(b => b.floors)
                .ThenInclude(f => f.zones)
                .ThenInclude(z => z.meters);
        }
    }
}
