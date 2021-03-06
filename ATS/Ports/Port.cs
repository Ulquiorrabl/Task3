﻿using System;
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

        public event EventHandler<string> CallEnded;


        public Region Region { get; private set; }     
        public PortStatus Status { get; private set; }
        public string Number { get; private set; }
        private string connectedNumber;
        public Port(Region region, string number)
        {
            connectedNumber = "";
            this.Region = region;
            this.Number = number;
        }

        public override string ToString()
        {
            return this.Number;
        }

        public void ConnectToNumber(string number)
        {
            if (Status != PortStatus.Busy)
            {
                Status = PortStatus.Busy;
                connectedNumber = number;
                Call?.Invoke(this, number);
            }
        }

        public void ConnectedToPort(string number)
        {
            if(Status != PortStatus.Busy)
            {
                Status = PortStatus.Busy;
                connectedNumber = number;
                IncomingCall?.Invoke(this, number);
            }
        }

        public void EndCall()
        {
            if(Status != PortStatus.Online)
            {
                Status = PortStatus.Online;
                CallEnded?.Invoke(this, connectedNumber);
            }
            connectedNumber = "";
        }

    }
}
