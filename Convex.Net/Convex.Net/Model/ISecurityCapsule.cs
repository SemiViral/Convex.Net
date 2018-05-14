using System.Security.Cryptography;

namespace Convex.Net.Model {
    public interface ISecurityCapsule {
        #region MEMBERS

        SHA512 Hash { get; }
        bool IsInitialised { get; set; }

        #endregion

        void Initialise(string passphrase);
    }
}
