using FakeItEasy;
using Meter_API.Controllers;
using Meter_API.Domain.requests;
using Meter_API.Domain.response;
using Meter_API.Exceptions;
using Meter_API.Models;
using Meter_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{
    public class SearchControllerFakeItEasyTests
    {

        [Fact]
        public void ShouldReturn200OnSuccess()
        {
            QueryParameters qp = new QueryParameters();
            var mockSearchService =  A.Fake<ISearchService>();
            A.CallTo(() => mockSearchService.Search(qp)).Returns(new Cities()); 
            var sut = new SearchController(mockSearchService);
            
            var result = sut.GetMeters(qp);
            var res =(OkObjectResult) result.Result;
            var objRes = (MeterResponse)res.Value;

          
            Assert.Equal(200,res.StatusCode);
            Assert.Null(objRes.Error);
            Assert.Null(objRes.Warning);
            Assert.NotNull(objRes.Data);

            A.CallTo(()=>mockSearchService.Search(qp)).MustHaveHappened();
        }


        [Fact]
        public void ShouldReturn404NotFoundWhenInvalidInputIsPassed()
        {
            QueryParameters qp = new QueryParameters();
            var mockSearchService = A.Fake<ISearchService>();
            A.CallTo(() => mockSearchService.Search(qp)).Throws(new InvalidInputException("Invalid Input"));
            var sut = new SearchController(mockSearchService);

            var result = sut.GetMeters(qp);
            var res = (NotFoundObjectResult)result.Result;
            var objRes = (MeterResponse)res.Value;

            Assert.Equal(404, res.StatusCode);
            Assert.Null(objRes.Error);
            Assert.Equal("Invalid Input",objRes.Warning);
            Assert.Null(objRes.Data);

            A.CallTo(() => mockSearchService.Search(qp)).MustHaveHappened();
        }


        [Fact]
        public void ShouldReturn404NotFoundWhenErrorOccuredIsPassed()
        {
            QueryParameters qp = new QueryParameters();
            var mockSearchService = A.Fake<ISearchService>();
            A.CallTo(() => mockSearchService.Search(qp)).Throws(new Exception("System Error"));
            var sut = new SearchController(mockSearchService);

            var result = sut.GetMeters(qp);
            var res = (NotFoundObjectResult)result.Result;
            var objRes = (MeterResponse)res.Value;

            Assert.Equal(404, res.StatusCode);
            Assert.Equal("System Error", objRes.Error);
            Assert.Null(objRes.Warning);
            Assert.Null(objRes.Data);

            A.CallTo(() => mockSearchService.Search(qp)).MustHaveHappened();
        }
    }
}