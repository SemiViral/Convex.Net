using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class MessagesController : Controller {
        //GET api/Messages
        [HttpGet]
        public string Get() {
            return "message";
        }
    }
}
