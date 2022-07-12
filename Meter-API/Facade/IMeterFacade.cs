using Meter_API.Domain.requests;

namespace Meter_API.Facade
{
    public interface IMeterFacade
    {
        object GetSearchDataByInformationAtAndNameParam(QueryParameters queryParameters);
        object GetSearchDataByInformationAt(string req);
        object? GetAllSearchData();
    }
}
