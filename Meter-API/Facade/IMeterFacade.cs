using Meter_API.Domain.requests;

namespace Meter_API.Facade
{
    public interface IMeterFacade
    {
        object? findAllByParam(QueryParameters qp);
    }
}
