using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        public KeyValuePair<int, byte[]> PublicKey { get;}
        private byte[] Hash { get; }

        #endregion


        public Handshake() {
            using (SHA512 hashManager = SHA512.Create()) {
                Hash = hashManager.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }
        }

        public bool Verify(string passphrase) {
            return Hash.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }
    }
}
