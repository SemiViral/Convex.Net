using System.Net;
using Convex.IRC;

namespace Convex.Net.Models {
    public class Server {
        #region MEMBERS

        private Client client { get; }

        public IPEndPoint IpAddress { get; }

        #endregion

        public Server(IPEndPoint ipAddress) {
            IpAddress = ipAddress;

            client = new Client(IpAddress);
        }
    }
}
