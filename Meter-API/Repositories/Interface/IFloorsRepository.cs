using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IFloorsRepository
    {
        List<Floors> FindAll(QueryParameters qp);
    }
}
