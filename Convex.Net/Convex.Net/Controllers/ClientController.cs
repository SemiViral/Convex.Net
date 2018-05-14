using Microsoft.AspNetCore.Mvc;

namespace Convex.Net.Controllers {
    [Route("api/[controller]")]
    public class ClientController {
        [HttpGet("{isAlive}")]
        public bool Get() {
            return true;
        }

        [HttpPost("{passphrase}")]
        public void Post(string passphrase) {

        }
    }
}
