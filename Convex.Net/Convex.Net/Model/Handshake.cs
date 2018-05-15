using System;
using System.Security.Cryptography;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private const int KEY_SIZE = 8;
        private const int BASE_SIZE = 4;

        private RandomNumberGenerator Random { get; }
        private Tuple<byte[], byte[]> PublicKey { get; }
        private byte[] PrivateKey { get; }

        public bool IsInitialised { get; }

        #endregion


        public Handshake() {
            Random = RandomNumberGenerator.Create();
            PublicKey = new Tuple<byte[], byte[]>(new byte[BASE_SIZE], new byte[KEY_SIZE]);
            PrivateKey = new byte[KEY_SIZE];

            InitialiseKeys();

            IsInitialised = true;
        }

        public string Decrypt(byte[] encryption, string data) {
            string decryptedData = string.Empty;


            return decryptedData;
        }


        private void InitialiseKeys() {
            PublicKeyBaseToRandomPrime();
            Random.GetBytes(PublicKey.Item2);
            Random.GetBytes(PrivateKey);
            EnsurePrivateKeySize();
        }

        private void EnsurePrivateKeySize() {
            while (BitConverter.ToInt64(PrivateKey, 0) > BitConverter.ToInt64(PublicKey.Item2, 0))
                Random.GetBytes(PrivateKey);
        }

        private void PublicKeyBaseToRandomPrime() {
            do {
                Random.GetBytes(PublicKey.Item1);
            } while (!IsPrime(BitConverter.ToInt32(PublicKey.Item1, 0)));
        }

        private static bool IsPrime(int number) {
            if (number == 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
