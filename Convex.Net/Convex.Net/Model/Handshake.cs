using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Convex.Net.Model {
    public class Handshake {
        #region MEMBERS
        
        private RandomNumberGenerator Random { get; }
        private PublicKey PublicKey { get; }
        private int PrivateKey { get; set; }

        #endregion


        public Handshake() {
            Random = RandomNumberGenerator.Create();

            GeneratePrivateKey();


            PublicKey = new PublicKey();
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
