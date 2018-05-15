using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS

        private const int KEY_SIZE = 512;
        private const int BASE_SIZE = 4;

        public bool IsInitialised { get; }

        private RandomNumberGenerator Random { get; }
        public byte[] Base { get; }
        public int BaseInt32 => BitConverter.ToInt32(Base, 0);

        public byte[] PublicKey {
            get => publicKey;
            private set {
                if (value.Length != KEY_SIZE)
                    throw new ArgumentException($"Length of new byte array must be {KEY_SIZE} bytes");

                publicKey = value;
                PublicKeyInt512 = new BigInteger(publicKey);
            }
        }

        private byte[] PrivateKey {
            get => privateKey;
            set {
                if (value.Length != KEY_SIZE)
                    throw new ArgumentException($"Length of new byte array must be {KEY_SIZE} bytes");

                privateKey = value;
                PrivateKeyInt512 = new BigInteger(privateKey);
            }
        }

        public BigInteger PublicKeyInt512 { get; set; }
        private BigInteger PrivateKeyInt512 { get; set; }

        private byte[] privateKey;
        private byte[] publicKey;

        #endregion


        public Handshake() {
            Random = RandomNumberGenerator.Create();
            Base = new byte[BASE_SIZE];
            PublicKey = new byte[KEY_SIZE];
            PrivateKey = new byte[KEY_SIZE];

            InitialiseKeys();

            IsInitialised = true;

            // todo separate PublicKey and PrivateKey into field/Property relationship
            // todo set up BigIntegers in propertyies that update when field is changed
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
            Random.GetBytes(PublicKey);
            Random.GetBytes(PrivateKey);

            PublicKeyInt512 = new BigInteger(PublicKey);
            PrivateKeyInt512 = new BigInteger(PrivateKey);

            EnsurePrivateKeySize();
        }

        private void PublicKeyBaseToRandomPrime() {
            do {
                Random.GetBytes(Base);
            } while (!IsPrime(BitConverter.ToInt32(PublicKey, 0)));
        }

        private void EnsurePrivateKeySize() {
            while (PrivateKeyInt512 > PublicKeyInt512)
                Random.GetBytes(PrivateKey);
        }

        #endregion

        #region CRYPTO

        public string Encrypt(byte[] interprivateKey, string data) {
            byte[] masterKey = GetMasterKey(interprivateKey);
            string encrytpedData = string.Empty;

            if (interprivateKey == null || interprivateKey.Length != KEY_SIZE)
                throw new ArgumentException($"Interprivate Key need to be {KEY_SIZE * 8} bit!");

            return encrytpedData;
        }

        public string Decrypt(byte[] externalKey, string data) {
            byte[] masterKey = GetMasterKey(externalKey);
            string decryptedData = string.Empty;


            return decryptedData;
        }

        private byte[] GetMasterKey(byte[] externalKey) {
            return (BaseInt32 ^ (PrivateKeyInt512 * new BigInteger(externalKey) % PublicKeyInt512)).ToByteArray();
        }

        #endregion
    }
}
