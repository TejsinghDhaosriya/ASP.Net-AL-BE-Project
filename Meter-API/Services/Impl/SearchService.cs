using Meter_API.Domain.requests;
using Meter_API.Facade;
using Meter_API.Repositories;
using Meter_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

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
        if (IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterFacade.findAllCitiesData();
        if (IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterFacade.findAllByInformationAt(qp.informationAt);
        if (!IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterFacade.findAllCitiesDataByName(qp.name);
        if (!IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterFacade.findAllByInformationAtAndName(qp);

        return _meterFacade.findAllCitiesData();
    }


    private static bool IsEmpty(string req)
    {
        var isNullOrEmpty = string.IsNullOrEmpty(req);
        return isNullOrEmpty;
    }
}