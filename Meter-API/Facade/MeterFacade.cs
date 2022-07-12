using Meter_API.Domain.requests;
using Meter_API.Exceptions;
using Meter_API.Models;
using Meter_API.Repositories;
using Meter_API.Repositories.Interface;

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

    public object? findAllByParam(QueryParameters qp)
    {
        return qp.informationAt.ToLower() switch
        {
            "cities" => _citiesRepository.FindAll(qp),
            "facilities" => _facilitiesRepository.FindAll(qp),
            "buildings" => _buildingsRepository.FindAll(qp),
            "floors" => _floorsRepository.FindAll(qp),
            "zones" => _zonesRepository.FindAll(qp),
            "meters" => _metersRepository.FindAll(qp),
            _ => throw new InvalidInputException("Please pass a valid informationAt")
        };
    }

    public object? findAllByInformationAt(string req)
    {
        // return req.ToLower() switch
        // {
        //     "cities" => _citiesRepository.FindAll(),
        //     "facilities" => _facilitiesRepository.FindAll(),
        //     "buildings" => _buildingsRepository.FindAll(),
        //     "floors" => _floorsRepository.FindAll(),
        //     "zones" => _zonesRepository.FindAll(),
        //     "meters" => _metersRepository.FindAll(),
        //     _ => throw new InvalidInputException("Please pass a valid informationAt")
        // };

        return null;
    }

    public IEnumerable<Cities> findAllCitiesData()
    {
        return null;
    }

    public IEnumerable<Cities> findAllCitiesDataByName(string qpName)
    {
        return _citiesRepository.FindAllByName(qpName);
    }


    public object? findAllByInformationAtAndName(QueryParameters qp)
    {
        return qp.informationAt.ToLower() switch
        {
            "cities" => _citiesRepository.FindAllByName(qp.name),
            "facilities" => _facilitiesRepository.FindAllByName(qp.name),
            "buildings" => _buildingsRepository.FindAllByName(qp.name),
            "floors" => _floorsRepository.FindAllByName(qp.name),
            "zones" => _zonesRepository.FindAllByName(qp.name),
            "meters" => _metersRepository.FindAllByName(qp.name),
            _ => throw new InvalidInputException("Please pass a valid informationAt")
        };
    }

}