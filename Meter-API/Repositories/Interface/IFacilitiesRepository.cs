using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IFacilitiesRepository
    {
        IEnumerable<Facilities> FindAll(QueryParameters qp);

        IEnumerable<Facilities> FindAllByName(string qpName);
    }
}
