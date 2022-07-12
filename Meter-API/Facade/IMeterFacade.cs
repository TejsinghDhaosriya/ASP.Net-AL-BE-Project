using Meter_API.Domain.requests;
using Meter_API.Models;

namespace Meter_API.Facade
{
    public interface IMeterFacade
    {
        object? findAllByParam(QueryParameters qp);
    }
}
