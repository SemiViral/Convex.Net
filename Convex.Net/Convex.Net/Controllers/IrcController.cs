using System;
using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class IrcController : Controller {
        private IrcService IrcClientReference { get; }

        public IrcController(IrcService service) {
            IrcClientReference = service;
        }

        //GET api/irc
        [HttpGet]
        public string Get() {
            return string.Join("\n", IrcClientReference.GetMessagesByDateTimeOrDefault(DateTime.Now, DateTimeOrdinal.Before));
        }
    }
}
