using System;
using System.Collections.Generic;
using System.Linq;
using Convex.IRC.Model;
using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class IrcController : Controller {
        #region MEMBERS

        private IrcService IrcClientReference { get; }

        #endregion

        public IrcController(IrcService service) {
            IrcClientReference = service;
        }

        //GET api/irc
        [HttpGet("{dateTime}")]
        public List<ServerMessage> Get(DateTime dateTime) {
            return IrcClientReference.GetMessagesByDateTimeOrDefault(dateTime, DateTimeOrdinal.After).ToList();
        }
    }
}
