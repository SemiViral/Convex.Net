using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Convex.Net {
    public class StateObject {
        #region MEMBERS

        public const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public StringBuilder StrBuilder = new StringBuilder();

        public Socket WorkSocket;

        #endregion
    }

    public class AsynchronousSocketListener {
        #region MEMBERS

        public static ManualResetEvent tasksCompleted = new ManualResetEvent(false);

        #endregion

        public static void BeginListen() {
            byte[] bytes = new byte[1024];

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                bool doListen = true;

                while (doListen) {
                    tasksCompleted.Reset();

                    Console.WriteLine("Waiting for connection...");
                    listener.BeginAccept(AcceptCallback, listener);

                    tasksCompleted.WaitOne();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadKey();
        }

        public static void AcceptCallback(IAsyncResult asyncResult) {
            tasksCompleted.Set();

            Socket listener = (Socket)asyncResult.AsyncState;
            Socket handler = listener.EndAccept(asyncResult);

            StateObject state = new StateObject {WorkSocket = handler};
            handler.BeginReceive(state.Buffer, 0, StateObject.BUFFER_SIZE, 0, ReadCallback, state);

            // todo implement ReadCallback
        }
    }
}
