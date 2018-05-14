using System;
using System.Security.Cryptography;
using System.Text;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private RandomNumberGenerator Random { get; }
        private byte[] PublicKey { get; }
        private byte[] PrivateKey { get; }

        public bool IsInitialised { get; }

        #endregion


        public Handshake(int privateKeySize) {
            Random = RandomNumberGenerator.Create();

            using (RSACryptoServiceProvider cryptoService = new RSACryptoServiceProvider()) {
                PublicKey = GenerateKey(privateKeySize);
                PrivateKey = GenerateKey(privateKeySize);

                RSAParameters CryptoParams = cryptoService.ExportParameters(false);
                cryptoService.ImportParameters(CryptoParams.Modulus = PublicKey);
                RijndaelManaged RM = new RijndaelManaged();
            }

            IsInitialised = true;
        }

        public bool Verify(string passphrase) {
            return PrivateKey.(Encoding.UTF8.GetBytes(passphrase));
        }

        private byte[] GenerateKey(int size) {
            byte[] key = new byte[size];
            Random.GetNonZeroBytes(key);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(key);

            return key;
        }

        private static bool IsPrime(int number) {
            if (number == 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2) {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
