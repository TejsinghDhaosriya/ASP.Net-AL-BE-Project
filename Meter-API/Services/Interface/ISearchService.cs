using Meter_API.Domain.requests;

namespace Meter_API.Services.Interface
{
    public interface ISearchService
    {

        List<object> Search(QueryParameters queryParameters);
    }
}
