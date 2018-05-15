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

        private int PublicKeyBaseInt64 => BitConverter.ToInt32(PublicKey.Item1, 0);

        #endregion


        public Handshake() {
            Random = RandomNumberGenerator.Create();
            PublicKey = new Tuple<byte[], byte[]>(new byte[BASE_SIZE], new byte[KEY_SIZE]);
            PrivateKey = new byte[KEY_SIZE];

            InitialiseKeys();

            IsInitialised = true;
        }

        private long PublicKeyInt64() {
            return BitConverter.ToInt64(PublicKey.Item2, 0);
        }

        private long PrivateKeyInt64() {
            return BitConverter.ToInt64(PrivateKey, 0);
        }

        #region UTIL

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

        #endregion

        #region INIT

        private void InitialiseKeys() {
            PublicKeyBaseToRandomPrime();
            Random.GetBytes(PublicKey.Item2);
            Random.GetBytes(PrivateKey);
            EnsurePrivateKeySize();
        }

        private void PublicKeyBaseToRandomPrime() {
            do {
                Random.GetBytes(PublicKey.Item1);
            } while (!IsPrime(BitConverter.ToInt32(PublicKey.Item1, 0)));
        }

        private void EnsurePrivateKeySize() {
            while (PrivateKeyInt64() > PublicKeyInt64())
                Random.GetBytes(PrivateKey);
        }

        #endregion

        #region CRYPTO

        public string Encrypt(byte[] privateKey, string data) {
            byte[] masterKey = GetMasterKey(privateKey);
            string encrytpedData = string.Empty;

            return encrytpedData;
        }

        public string Decrypt(byte[] privateKey, string data) {
            byte[] masterKey = GetMasterKey(privateKey);
            string decryptedData = string.Empty;


            return decryptedData;
        }

        private byte[] GetMasterKey(byte[] privateKey) {
            return BitConverter.GetBytes(PublicKeyBaseInt64 ^ (PrivateKeyInt64() * BitConverter.ToInt64(privateKey, 0) % PublicKeyInt64()));
        }

        #endregion
    }
}
