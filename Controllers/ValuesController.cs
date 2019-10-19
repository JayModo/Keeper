using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("werk")]
  public class ValueController : ControllerBase
  {
    [HttpGet]
    public ActionResult<string> test()
    {
      return Ok("ok?");
    }
  }
}