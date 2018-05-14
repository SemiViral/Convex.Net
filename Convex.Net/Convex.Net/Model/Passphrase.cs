using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class Passphrase {
        #region MEMBERS

        private byte[] Hash { get; }

        #endregion


        public Passphrase(string passphrase) {
            using (SHA512 hashManager = SHA512.Create()) {
                Hash = hashManager.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }
        }

        public bool Verify(string passphrase) {
            byte[] tryPassHash;

            using (SHA512 hashManager = SHA512.Create()) {
                tryPassHash = hashManager.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }

            return Hash.SequenceEqual(tryPassHash);
        }
    }
}
