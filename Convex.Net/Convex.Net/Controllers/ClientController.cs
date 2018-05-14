using Convex.Net.Model;
using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class ClientController {
        #region MEMBERS

        private Passphrase Passphrase { get; }

        #endregion

        public ClientController(Passphrase passphrase) {
            Passphrase = passphrase;
        }

        [HttpGet("{isAlive}")]
        public bool Get() {
            return true;
        }

        [HttpGet("{passphrase}")]
        public void Get(string passphrase) { }
    }
}
