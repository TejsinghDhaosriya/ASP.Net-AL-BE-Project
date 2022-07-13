using Meter_API.Domain.requests;
using Meter_API.Exceptions;
using Meter_API.Repositories.Interface;

namespace Meter_API.Facade;

public class MeterFacade : IMeterFacade
{
    private readonly ICitiesRepository _citiesRepository;
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IBuildingsRepository _buildingsRepository;
    private readonly IFloorsRepository _floorsRepository;
    private readonly IZonesRepository _zonesRepository;
    private readonly IMetersRepository _metersRepository;

    public MeterFacade(IFacilitiesRepository facilitiesRepository, IBuildingsRepository buildingsRepository, IFloorsRepository floorsRepository, IZonesRepository zonesRepository, ICitiesRepository citiesRepository, IMetersRepository metersRepository)
    { _facilitiesRepository = facilitiesRepository;
        _buildingsRepository = buildingsRepository;
        _floorsRepository = floorsRepository;
        _zonesRepository = zonesRepository;
        _citiesRepository = citiesRepository;
        _metersRepository = metersRepository;
    }

    public List<object> findAllByParam(QueryParameters qp)
    {
        return new List<object>
        {
            qp.informationAt.ToLower() switch
            {
                "cities" => _citiesRepository.FindAll(qp),
                "facilities" => _facilitiesRepository.FindAll(qp),
                "buildings" => _buildingsRepository.FindAll(qp),
                "floors" => _floorsRepository.FindAll(qp),
                "zones" => _zonesRepository.FindAll(qp),
                "meters" => _metersRepository.FindAll(qp),
                _ => throw new InvalidInputException("Please pass a valid informationAt, " +
                                                     "accepted values are [cities,facilities, buildings, floors, zones, meters]")
            }
        };
    }

    
}