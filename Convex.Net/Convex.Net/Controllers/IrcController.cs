using System;
using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class IrcController : Controller {
        //GET api/irc
        [HttpGet]
        public string Get() {
            return "message";
        }
    }
}
