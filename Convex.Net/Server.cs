using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Convex.Net {
    public class Server {
        private readonly Socket PrimarySocket;

        public Server() {
            PrimarySocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        }

        public static int Port => 99;

        public int Backlog { get; set; } = 5;

        public void Start() {
            PrimarySocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            PrimarySocket.Listen(Backlog);
        }

        public async Task Accept() {
            await PrimarySocket.AcceptAsync();
        }
    }
}
