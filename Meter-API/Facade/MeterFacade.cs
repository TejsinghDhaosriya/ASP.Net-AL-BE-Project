using Meter_API.Domain.requests;
using Meter_API.Repositories;
using Meter_API.Repositories.Impl;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Facade;

public class MeterFacade : IMeterFacade
{
    private readonly MetersDbContext _context;
    private readonly ICitiesRepository _citiesRepository;
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IBuildingsRepository _buildingsRepository;
    private readonly IFloorsRepository _floorsRepository;
    private readonly IZonesRepository _zonesRepository;
    private readonly IMetersRepository _metersRepository;

    public MeterFacade(MetersDbContext dbContext, IFacilitiesRepository facilitiesRepository, IBuildingsRepository buildingsRepository, IFloorsRepository floorsRepository, IZonesRepository zonesRepository, ICitiesRepository citiesRepository, IMetersRepository metersRepository)
    {
        _context = dbContext;
        _facilitiesRepository = facilitiesRepository;
        _buildingsRepository = buildingsRepository;
        _floorsRepository = floorsRepository;
        _zonesRepository = zonesRepository;
        _citiesRepository = citiesRepository;
        _metersRepository = metersRepository;
    }

    public object? GetSearchDataByInformationAt(string req)
    {
        return req.ToLower() switch
        {
            "cities" => _citiesRepository.FindAll(),
            "facilities" => _facilitiesRepository.FindAll(),
            "buildings" => _buildingsRepository.FindAll(),
            "floors" => _facilitiesRepository.FindAll(),
            "zones" => _zonesRepository.FindAll(),
            "meters" => _metersRepository.FindAll(),
            _ => throw new Exception("Please pass a valid informationAt")
        };
    }

    public object? GetAllSearchData()
    {
        return _citiesRepository.FindAll();
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