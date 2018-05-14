using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private byte[] Hash { get; }

        #endregion


        public Handshake(string passphrase) {
            using (SHA512 hashManager = SHA512.Create()) {
                Hash = hashManager.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }
        }

        public bool Verify(string passphrase) {
            return Hash.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }
    }
}
