using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Convex.IRC;
using Convex.IRC.ComponentModel.Event;
using Convex.IRC.Model;

namespace Convex.Net.Model {
    public class IrcService {
        #region MEMBERS

        public Client Client { get; }

        public IPEndPoint IpAddress { get; }

        private List<ServerMessage> Messages { get; }

        #endregion

        public IrcService(IPEndPoint ipAddress) {
            IpAddress = ipAddress;

            Client = new Client(IpAddress);
            Client.Server.ChannelMessaged += OnClientChannelMessaged;

            Messages = new List<ServerMessage>();

            Debug.WriteLine("IrcService started");
        }

        #region EVENT

        private Task OnClientChannelMessaged(object sender, ServerMessagedEventArgs args) {
            Messages.Add(args.Message);

            Debug.WriteLine(args.Message.RawMessage);

            return Task.CompletedTask;
        }

        #endregion

        #region INIT

        public async Task Initialise() {
            await Client.Initialise();
        }

        #endregion

        #region METHODS

        public IEnumerable<ServerMessage> GetMessagesByDateTimeOrDefault(DateTime referenceTime, DateTimeOrdinal dateTimeOrdinal) {
            IEnumerable<ServerMessage> temporaryList = null;

            switch (dateTimeOrdinal) {
                case DateTimeOrdinal.Before:
                    temporaryList = Messages.Where(message => message.Timestamp > referenceTime);
                    break;
                case DateTimeOrdinal.After:
                    temporaryList = Messages.Where(message => message.Timestamp < referenceTime);
                    break;
                default:
                    break;
            }

            return temporaryList;
        }

        #endregion
    }

    public enum DateTimeOrdinal {
        Before,
        After
    }
}
