using Meter_API.Domain.requests;

namespace Meter_API.Repositories
{
    public interface IMeterRepository
    {
        object GetSearchDataByInformationAtAndNameParam(QueryParameters queryParameters);
        object GetSearchDataByInformationAt(string req);
        object? GetAllSearchData();
    }
}
