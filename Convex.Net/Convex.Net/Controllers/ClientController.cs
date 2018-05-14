using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class ClientController {
        #region MEMBERS

        private Passphrase Passphrase { get; }
        public ImmutableArray<Guid> VerifiedClients { get; }

        #endregion

        public ClientController(Passphrase passphrase) {
            Passphrase = passphrase;
            VerifiedClients = ImmutableArray<Guid>.Empty;
        }

        [HttpGet]
        public bool Get() {
            return true;
        }

        [HttpPost]
        public void Post(string guid, string passphrase) {
            return Passphrase.Verify(passphrase);
        }
    }
}
