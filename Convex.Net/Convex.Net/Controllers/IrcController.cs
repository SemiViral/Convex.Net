using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class IrcController : Controller {
        //GET api/Messages
        [HttpGet]
        public string Get() {
            return "message";
        }
    }
}
