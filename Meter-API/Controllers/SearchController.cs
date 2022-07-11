using Meter_API.Domain.requests;
using Meter_API.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Meter_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService iSearchService)
        {
            _searchService = iSearchService;
        }


        [HttpGet("search")]
        public ActionResult<object>? GetMeters([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                return _searchService.Search(queryParameters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}