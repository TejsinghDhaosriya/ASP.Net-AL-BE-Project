using Meter_API.Domain.requests;

namespace Meter_API.Services.Interface
{
    public interface ISearchService
    {

        object? Search(QueryParameters queryParameters);
    }
}
