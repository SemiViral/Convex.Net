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
    }
}
