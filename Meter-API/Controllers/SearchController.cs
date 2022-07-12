using Meter_API.Domain.requests;
using Meter_API.Domain.response;
using Meter_API.Exceptions;
using Meter_API.Services.Interface;
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
        public ActionResult<MeterResponse>? GetMeters([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                return Ok(new MeterResponse(_searchService.Search(queryParameters)));
            }
            catch (InvalidInputException ex)
            {
                return NotFound(new MeterResponse(warning: ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new MeterResponse(error:ex.Message));
            }
        }
    }
}