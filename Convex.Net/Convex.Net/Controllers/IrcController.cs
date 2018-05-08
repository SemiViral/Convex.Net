using System;
using System.Collections.Generic;
using System.Linq;
using Convex.IRC.Model;
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
            List<ServerMessage> temporaryList = IrcClientReference.GetMessagesByDateTimeOrDefault(DateTime.MinValue, DateTimeOrdinal.After).ToList();

            return string.Join("\n", temporaryList);
        }
    }
}
