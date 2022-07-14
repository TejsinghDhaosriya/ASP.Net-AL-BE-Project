using FakeItEasy;
using Meter_API.Domain.requests;
using Meter_API.Exceptions;
using Meter_API.Facade;
using Meter_API.Models;
using Meter_API.Repositories.Interface;

namespace UnitTests.Facade;

public class MeterFacadeFakeItEasyTest
{
    [Fact]
    public void ShouldThrowErrorWhenInvalidInformationAtIsPassed()
    {
        var qp = new QueryParameters
        {
            informationAt = "kuch bhi"
        };
        var sut = new MeterFacade(null, null, null, null, null, null);

        Action Result()
        {
            return (Action)sut.findAllByParam(qp);
        }

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
        var mockCitiesRepository = A.Fake<ICitiesRepository>();
        A.CallTo(() => mockCitiesRepository.FindAll(qp)).Returns(data);

        var sut = new MeterFacade(null, null, null, null, mockCitiesRepository, null);
        var result = sut.findAllByParam(qp);
        var res = (List<Cities>)result;

        Assert.Equal(data, res);

        A.CallTo(() => mockCitiesRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "cities")
            .MustHaveHappened();
    }

    [Fact]
    public void ShouldReturnFacilitiesData()
    {
        var data = new List<Facilities> { new() };
        var qp = new QueryParameters
        {
            informationAt = "facilities"
        };
        var mockFacilitiesRepository = A.Fake<IFacilitiesRepository>();
        A.CallTo(() => mockFacilitiesRepository.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(mockFacilitiesRepository, null, null, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Facilities>)result;

        Assert.Equal(data, res);

        A.CallTo(() => mockFacilitiesRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "facilities")
            .MustHaveHappened();
    }

    [Fact]
    public void ShouldReturnBuildingsData()
    {
        var data = new List<Buildings> { new() };
        var qp = new QueryParameters
        {
            informationAt = "buildings"
        };
        var mockBuildingsRepository = A.Fake<IBuildingsRepository>();
        A.CallTo(() => mockBuildingsRepository.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, mockBuildingsRepository, null, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Buildings>)result;

        Assert.Equal(data, res);
        A.CallTo(() => mockBuildingsRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "buildings")
            .MustHaveHappened();
    }

    [Fact]
    public void ShouldReturnFloorsData()
    {
        var data = new List<Floors> { new() };
        var qp = new QueryParameters
        {
            informationAt = "floors"
        };
        var mockFloorsRepository = A.Fake<IFloorsRepository>();
        A.CallTo(() => mockFloorsRepository.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, mockFloorsRepository, null, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Floors>)result;

        Assert.Equal(data, res);

        A.CallTo(() => mockFloorsRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "floors")
            .MustHaveHappened();
    }

    [Fact]
    public void ShouldReturnZonesData()
    {
        var data = new List<Zones> { new() };
        var qp = new QueryParameters
        {
            informationAt = "zones"
        };
        var mockZonesRepository = A.Fake<IZonesRepository>();
        A.CallTo(() => mockZonesRepository.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, null, mockZonesRepository, null, null);

        var result = sut.findAllByParam(qp);
        var res = (List<Zones>)result;

        Assert.Equal(data, res);

        A.CallTo(() => mockZonesRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "zones")
            .MustHaveHappened();
    }


    [Fact]
    public void ShouldReturnMetersData()
    {
        var data = new List<Meters> { new() };
        var qp = new QueryParameters
        {
            informationAt = "meters"
        };
        var mockMetersRepository = A.Fake<IMetersRepository>();
        A.CallTo(() => mockMetersRepository.FindAll(qp)).Returns(data);
        var sut = new MeterFacade(null, null, null, null, null, mockMetersRepository);

        var result = sut.findAllByParam(qp);
        var res = (List<Meters>)result;

        Assert.Equal(data, res);
        A.CallTo(() => mockMetersRepository
                .FindAll(qp))
            .WhenArgumentsMatch(q => q.Get<QueryParameters>(0).informationAt == "meters")
            .MustHaveHappened();
    }
}