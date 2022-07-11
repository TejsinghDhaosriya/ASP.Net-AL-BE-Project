using Meter_API.Domain.requests;
using Microsoft.AspNetCore.Mvc;

namespace Meter_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SearchController : ControllerBase
    {
    
        [HttpGet("search")]
        public ActionResult GetMeters([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}