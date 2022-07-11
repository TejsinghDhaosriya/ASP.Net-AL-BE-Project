using System.Collections;
using Meter_API.Domain.requests;
using Meter_API.Models;
using Meter_API.Repositories;
using Meter_API.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Services.Interface
{
    public  class SearchService:ISearchService
    {
        private readonly MetersDbContext _context;
        public SearchService(MetersDbContext dbContext )
        {
            _context = dbContext;
        }

        public object? Search(QueryParameters qp)
        {

            if(IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
                 return _context.Cities;
            else if (IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
                return GetSearchDataByInformationAt(qp.informationAt);
            else if (!IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
                return _context.Cities.FirstOrDefault(s => s != null && qp.name.Equals(s.name));
            else if (!IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
                return GetSearchDataByInformationAtAndNameParam(qp);

            return _context.Cities;
        }

        private object? GetSearchDataByInformationAt(string req)
        {
            return req.ToLower() switch
            {
                "cities" => _context.Cities.Include(c=>c.facilities.Select(
                    f=>f.buildings)).ToList(),
                "facilities" => _context.Facilities,
                "buildings" => _context.Buildings,
                "floors" => _context.Floors,
                "zones" => _context.Zones,
                "meters" => _context.Meters,
                _ => throw new Exception("Please pass a valid informationAt")
            };
        }
        // "cities" => _context.Cities.Include(c=>c.facilities.Select(
        // f=>f.buildings.Select(b=>b.floors.Select(
        // f=>f.zones.Select(
        // z=>z.meters))))),
        private object? GetSearchDataByInformationAtAndNameParam(QueryParameters qp)
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
      

        private static bool IsEmpty(string req)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(req);
            return isNullOrEmpty;
        }
    }
}
