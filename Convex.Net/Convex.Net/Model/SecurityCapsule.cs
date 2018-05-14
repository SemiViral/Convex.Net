using System.Security.Cryptography;

namespace Convex.Net.Model {
    public class SecurityCapsule {
        #region MEMBERS

        private SHA512 Hash { get; }

        public bool IsInitialised { get; private set; }

        #endregion

        #region INTERFACE IMPLEMENTATION

        public void Initialise(string passphrase) {
        }

        #endregion
    }
}
