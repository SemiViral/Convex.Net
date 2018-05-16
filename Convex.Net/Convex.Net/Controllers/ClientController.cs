using System;
using System.Collections.Immutable;
using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class ClientController {
        #region MEMBERS

        private Handshake Handshake { get; }
        private ImmutableArray<Guid> VerifiedClients { get; }

        #endregion

        public ClientController(Handshake handshake) {
            Handshake = handshake;
            VerifiedClients = ImmutableArray<Guid>.Empty;
        }

        [HttpGet]
        public bool Get() {
            return true;
        }

        [HttpPost]
        public void Post(byte[] externalKey) {
            // VerifiedClients.Add(Guid.Parse(guid));
        }
    }
}
