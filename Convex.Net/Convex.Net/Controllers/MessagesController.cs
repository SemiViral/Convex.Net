using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class MessagesController : Controller {
        //GET api/Messages
        [HttpGet("{datetime}")]
        public void Get(string lastMessageReceivedDateTime) {
            // todo get logic
        }
    }
}
