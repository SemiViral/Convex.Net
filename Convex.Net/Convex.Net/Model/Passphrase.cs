using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class SecurityCapsule {
        #region MEMBERS

        private string Hash { get; }

        #endregion


        public SecurityCapsule(string passphrase) {
            using (SHA512 hashManager = SHA512.Create()) {
                Hash = hashManager.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }
        }
    }
}
