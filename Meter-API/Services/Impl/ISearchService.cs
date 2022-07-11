using Meter_API.Domain.requests;

namespace Meter_API.Services.Impl
{
    public interface ISearchService
    {

        object? Search(QueryParameters queryParameters);
    }
}
