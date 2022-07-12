using Meter_API.Domain.requests;
using Meter_API.Exceptions;
using Meter_API.Facade;
using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Moq;

namespace UnitTests.Facade;

public class MeterFacadeTest
{
    [Fact]
    public void ShouldThrowErrorWhenInvalidInformationAtIsPassed()
    {
        var qp = new QueryParameters
        {
            informationAt = "kuch bhi"
        };
        var sut = new MeterFacade(null, null, null, null, null, null);
        
        Action Result ()=> (Action)sut.findAllByParam(qp);
        
        var exception = Assert.Throws<InvalidInputException>(Result);
        Assert.Equal("Please pass a valid informationAt, " +
                     "accepted values are [cities,facilities, buildings, floors, zones, meters]", exception.Message);
    }

    [Fact]
    public void ShouldReturnCitiesData()
    {
        var data = new List<Cities> { new() };
        var qp = new QueryParameters
        {
            informationAt = "cities"
        };
        var mockCitiesRepository = new Mock<ICitiesRepository>();
        mockCitiesRepository.Setup(facade => facade.FindAll(qp)).Returns(data);

        var sut = new MeterFacade(null, null, null, null, mockCitiesRepository.Object, null);
        var result = sut.findAllByParam(qp);
        var res = (List<Cities>)result;

        Assert.Equal(data, res);


        mockCitiesRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "cities")), Times.Once);
    }

    [Fact]
    public void ShouldReturnFacilitiesData()
    {
        var data = new List<Facilities> { new() };
        var qp = new QueryParameters
        {
            informationAt = "facilities"
        };
        var mockFacilitiesRepository = new Mock<IFacilitiesRepository>();
        mockFacilitiesRepository.Setup(facade => facade.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(mockFacilitiesRepository.Object, null, null, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Facilities>)result;

        Assert.Equal(data, res);


        mockFacilitiesRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "facilities")), Times.Once);
    }

    [Fact]
    public void ShouldReturnBuildingsData()
    {
        var data = new List<Buildings> { new() };
        var qp = new QueryParameters
        {
            informationAt = "buildings"
        };
        var mockBuildingsRepository = new Mock<IBuildingsRepository>();
        mockBuildingsRepository.Setup(facade => facade.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, mockBuildingsRepository.Object, null, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Buildings>)result;

        Assert.Equal(data, res);


        mockBuildingsRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "buildings")), Times.Once);
    }

    [Fact]
    public void ShouldReturnFloorsData()
    {
        var data = new List<Floors> { new() };
        var qp = new QueryParameters
        {
            informationAt = "floors"
        };
        var mockFloorsRepository = new Mock<IFloorsRepository>();
        mockFloorsRepository.Setup(facade => facade.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, mockFloorsRepository.Object, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Floors>)result;

        Assert.Equal(data, res);


        mockFloorsRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "floors")), Times.Once);
    }

    [Fact]
    public void ShouldReturnZonesData()
    {
        var data = new List<Zones> { new() };
        var qp = new QueryParameters
        {
            informationAt = "zones"
        };
        var mockZonesRepository = new Mock<IZonesRepository>();
        mockZonesRepository.Setup(facade => facade.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, null, mockZonesRepository.Object, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Zones>)result;

        Assert.Equal(data, res);


        mockZonesRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "zones")), Times.Once);
    }


    [Fact]
    public void ShouldReturnMetersData()
    {
        var data = new List<Meters> { new() };
        var qp = new QueryParameters
        {
            informationAt = "meters"
        };
        var mockMetersRepository = new Mock<IMetersRepository>();
        mockMetersRepository.Setup(facade => facade.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, null, null, null, mockMetersRepository.Object);

        var result = sut.findAllByParam(qp);
        var res = (List<Meters>)result;

        Assert.Equal(data, res);


        mockMetersRepository.Verify(
            facade => facade.FindAll(It.Is<QueryParameters>(qp => qp.informationAt == "meters")), Times.Once);
    }
}