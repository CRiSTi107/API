using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Home : ControllerBase
    {
        [HttpGet]
        public ActionResult GetHomePage()
        {
            return Ok("API");
        }
    }
}