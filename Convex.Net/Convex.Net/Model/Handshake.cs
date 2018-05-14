using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private RandomNumberGenerator Random { get; }
        private RSACryptoServiceProvider CryptoService { get; }
        private byte[] PublicKey { get; }
        private byte[] PrivateKey { get; set; }

        public bool IsInitialised { get; }

        #endregion


        public Handshake(int privateKeySize) {
            CryptoService = new RSACryptoServiceProvider();

            Random = RandomNumberGenerator.Create();

            GenerateKey(privateKeySize);

            IsInitialised = true;
        }

        public bool Verify(string passphrase) {
            return PrivateKey.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }

        private byte[] GenerateKey(int size) {
            byte[] key = new byte[size];
            Random.GetNonZeroBytes(key);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(key);

            return key;
        }
    }
}
