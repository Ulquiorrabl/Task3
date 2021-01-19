using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Regions;
using Task3.Statuses;

namespace Task3.ATS.Ports
{
    class Port : IPort
    {
        public event EventHandler<string> Call;

        public event EventHandler<string> IncomingCall;

        public Region Region { get; private set; }     
        public PortStatus Status { get; private set; }
        public string Number { get; private set; }
        public Port(Region region, string number)
        {
            this.Region = region;
            this.Number = number;
        }

        public override string ToString()
        {
            return this.Number;
        }

        public void ConnectToNumber(string number)
        {
            Status = PortStatus.Busy;
            Console.WriteLine("Call Invoked");
            Call?.Invoke(this, number);
        }

        public void ConnectedToPort(string number)
        {
            Console.WriteLine("Incoming Call Invoked");
            Status = PortStatus.Busy;
            IncomingCall?.Invoke(this, number);
        }

    }
}
