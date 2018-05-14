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
        private int PrivateKey { get; }

        #endregion


        public Handshake() {
            Random = RandomNumberGenerator.Create();

            byte[] temp = new byte[32];
            Random.GetNonZeroBytes(temp);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);
            PrivateKey = BitConverter.ToInt32(temp, 0);


            PublicKey = new PublicKey();
        }

        public bool Verify(string passphrase) {
            return PrivateKey.SequenceEqual(Encoding.UTF8.GetBytes(passphrase));
        }

        private void GeneratePrivateKey(int size) {

        }
    }
}
