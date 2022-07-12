using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IZonesRepository
    {
        IEnumerable<Zones> FindAll(QueryParameters queryParameters);
        IEnumerable<Zones> FindAllByName(string qpName);
    }
}
