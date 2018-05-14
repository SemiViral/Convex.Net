using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        public KeyValuePair<int, byte[]> PublicKey { get;}
        private byte[] PrivateKey { get; }

        #endregion


        public Handshake() {
            
        }

        public bool Verify(string passphrase) {
            return PrivateKey.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }
    }
}
