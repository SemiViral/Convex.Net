using System;
using System.Collections.Immutable;

namespace Convex.Net.Model {
    public class ClientService {
        #region MEMBERS

        private Handshake Handshake { get; }
        private ImmutableArray<Guid> VerifiedClients { get; }

        #endregion

        public ClientService() {
            Handshake = new Handshake();
            VerifiedClients = new ImmutableArray<Guid>();
        }

        #region METHODS

        public bool IsClientVerified(Guid clientGuid) {
            return VerifiedClients.Contains(clientGuid);
        }

        #endregion
    }
}
