using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface ICitiesRepository
    {
        IEnumerable<Cities> FindAll(Domain.requests.QueryParameters qp);

        IEnumerable<Cities> FindAllByName(string qpName);
    }
}
