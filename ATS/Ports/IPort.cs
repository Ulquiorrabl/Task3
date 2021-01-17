using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Regions;
using Task3.Statuses;

namespace Task3.ATS.Ports
{
    interface IPort
    {
        string Number { get; }
        Region Region { get; }
        PortStatus Status { get; }
        void ConnectToNumber(string number);
        void ConnectedToPort(string number);

        event EventHandler<string> IncomingCall;

        event EventHandler<string> Call;
    }
}
