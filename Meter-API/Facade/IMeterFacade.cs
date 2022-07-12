using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Facade
{
    public interface IMeterFacade
    {
        object findAllByInformationAtAndName(QueryParameters queryParameters);
        object findAllByInformationAt(string req);
        IEnumerable<Cities> findAllCitiesData();
        IEnumerable<Cities> findAllCitiesDataByName(string qpName);
    }
}
