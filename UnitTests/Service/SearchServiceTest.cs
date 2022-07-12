using Meter_API.Domain.requests;
using Meter_API.Facade;
using Meter_API.Models;
using Meter_API.Services.Impl;
using Moq;

namespace UnitTests.Service;

public class SearchServiceTest
{
    [Fact]
    public void ShouldCallFindAllByParamMethodAndReturnCitiesData()
    {
        var data = new List<Cities> { new Cities() };
        var qp = new QueryParameters();
        var mockMeterFacade = new Mock<IMeterFacade>();
        mockMeterFacade.Setup(facade => facade.findAllByParam(qp)).Returns(data);

        var sut = new SearchService(mockMeterFacade.Object);

        var result = sut.Search(qp);
        var res = (List<Cities>)result;

        Assert.Equal(data, res);


        mockMeterFacade.Verify(
            facade => facade.findAllByParam(It.Is<QueryParameters>(qp => qp.informationAt == "cities")), Times.Once);
    }


    [Fact]
    public void ShouldCallFindAllByParamMethodAndReturnZonesData()
    {
        var data = new List<Zones> { new() };
        var qp = new QueryParameters { informationAt = "zones" };
        var mockMeterFacade = new Mock<IMeterFacade>();
        mockMeterFacade.Setup(facade => facade.findAllByParam(qp)).Returns(data);

        var sut = new SearchService(mockMeterFacade.Object);

        var result = sut.Search(qp);
        var res = (List<Zones>)result;

        Assert.Equal(data, res);


        mockMeterFacade.Verify(
            facade => facade.findAllByParam(It.Is<QueryParameters>(qp => qp.informationAt == "zones")), Times.Once);
    }
}