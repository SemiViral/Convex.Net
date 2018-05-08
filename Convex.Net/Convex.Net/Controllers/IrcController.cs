using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<ServerMessage> Get(string dateTime) {
            // DateTime.MinValue == 1/1/0001 12:00:00 AM (YYYYMMDDhhmmss 00010101120000)
            return IrcClientReference.GetMessagesByDateTimeOrDefault(DateTime.ParseExact(dateTime, "YYYYMMDDhhmmss", CultureInfo.InvariantCulture), DateTimeOrdinal.After).ToList();
        }
    }
}
