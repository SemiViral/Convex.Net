using System.Net;
using Convex.IRC;

namespace Convex.Net.Models {
    public class Server {
        #region MEMBERS

        private Client client { get; set; }

        private IPEndPoint ipAddress { get; set; }

        #endregion

        public Server(IPEndPoint ipAddress) { }

        #region INIT

        public void Initialise() { }

        #endregion
    }
}
