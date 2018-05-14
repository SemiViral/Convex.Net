using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private RandomNumberGenerator Random { get; }
        private PublicKey PublicKey { get; }
        private int PrivateKey { get; set; }

        public bool IsInitialised { get; }

        #endregion


        public Handshake(int privateKeySize) {
            Random = RandomNumberGenerator.Create();

            GeneratePrivateKey(privateKeySize);

            IsInitialised = true;
        }

        public bool Verify(string passphrase) {
            return PrivateKey.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }

        private void GeneratePrivateKey(int size) {
            byte[] privateKey = new byte[size];
            Random.GetNonZeroBytes(privateKey);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(privateKey);

            PrivateKey = BitConverter.ToInt32(privateKey, 0);
        }
    }
}
