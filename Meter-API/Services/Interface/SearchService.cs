using Meter_API.Domain.requests;
using Meter_API.Facade;
using Meter_API.Repositories;
using Meter_API.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Services.Interface;

public class SearchService : ISearchService
{
    private readonly MetersDbContext _context;
    private readonly IMeterFacade _meterRepository;
    public SearchService(MetersDbContext dbContext, IMeterFacade meterRepository)
    {
        _context = dbContext;
        _meterRepository = meterRepository;
    }

    public object? Search(QueryParameters qp)
    {
        if (IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterRepository.GetAllSearchData();
        if (IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterRepository.GetSearchDataByInformationAt(qp.informationAt);
        if (!IsEmpty(qp.name) && IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _context.Cities.FirstOrDefault(s => s != null && qp.name.Equals(s.name));
        if (!IsEmpty(qp.name) && !IsEmpty(qp.informationAt) && IsEmpty(qp.startDate) && IsEmpty(qp.endDate))
            return _meterRepository.GetSearchDataByInformationAtAndNameParam(qp);

        return _meterRepository.GetAllSearchData();
    }


    private static bool IsEmpty(string req)
    {
        var isNullOrEmpty = string.IsNullOrEmpty(req);
        return isNullOrEmpty;
    }
}