using Meter_API.Domain.requests;
using Meter_API.Facade;
using Meter_API.Repositories;
using Meter_API.Services.Interface;
using Meter_API.Utils;

namespace Meter_API.Services.Impl;

public class SearchService : ISearchService
{
    private readonly IMeterFacade _meterFacade;

    public SearchService(IMeterFacade meterFacade)
    {
        _meterFacade = meterFacade;
    }


    public object? Search(QueryParameters qp)
    {
        if (ApiUtils.IsEmpty(qp.informationAt))
            qp.informationAt="cities";
        return  _meterFacade.findAllByParam(qp);
    }
}