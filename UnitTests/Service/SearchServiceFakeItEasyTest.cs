using FakeItEasy;
using Meter_API.Domain.requests;
using Meter_API.Facade;
using Meter_API.Models;
using Meter_API.Services.Impl;

namespace UnitTests.Service;

public class SearchServiceFakeItEasyTest
{
    [Fact]
    public void ShouldCallFindAllByParamMethodAndReturnCitiesData()
    {
        var data = new List<Cities> { new Cities() };
        var qp = new QueryParameters();
        var mockMeterFacade = A.Fake<IMeterFacade>();
        A.CallTo(() => mockMeterFacade.findAllByParam(qp)).Returns(data);

        var sut = new SearchService(mockMeterFacade);

        var result = sut.Search(qp);
        var res = (List<Cities>)result;

        Assert.Equal(data, res);


        A.CallTo(()=>mockMeterFacade
                         .findAllByParam(qp))
            .WhenArgumentsMatch(q=>q.Get<QueryParameters>(0).informationAt=="cities")
                         .MustHaveHappened();
    }


    [Fact]
    public void ShouldCallFindAllByParamMethodAndReturnZonesData()
    {
        var data = new List<Zones> { new() };
        var qp = new QueryParameters { informationAt = "zones" };
        var mockMeterFacade = A.Fake<IMeterFacade>();
        A.CallTo(() => mockMeterFacade.findAllByParam(qp)).Returns(data);

        var sut = new SearchService(mockMeterFacade);

        var result = sut.Search(qp);
        var res = (List<Zones>)result;

        Assert.Equal(data, res);


        A.CallTo(() => mockMeterFacade
                .findAllByParam(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "zones")
            .MustHaveHappened();
    }
}