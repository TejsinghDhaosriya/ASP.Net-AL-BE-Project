using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IMetersRepository
    {
        IEnumerable<Meters> FindAll(QueryParameters qp);
        IEnumerable<Meters> FindAllByName(string qpName);
    }
}
