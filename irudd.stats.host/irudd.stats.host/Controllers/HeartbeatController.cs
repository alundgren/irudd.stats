using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irudd.Stats
{
    [Route("api/hb")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class HeartbeatController : ControllerBase
    {
        [HttpGet]
        public IActionResult Heartbeat()
        {
            return Ok(new { Date = DateTime.UtcNow.ToString("o") });
        }
    }
}
