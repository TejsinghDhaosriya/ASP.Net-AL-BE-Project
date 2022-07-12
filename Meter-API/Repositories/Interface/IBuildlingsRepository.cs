using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IBuildingsRepository
    {
        IEnumerable<Buildings> FindAll(QueryParameters qp);

        IEnumerable<Buildings> FindAllByName(string qpName);
    }
}
