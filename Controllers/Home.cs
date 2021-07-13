using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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