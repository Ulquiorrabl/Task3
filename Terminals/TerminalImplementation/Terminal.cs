using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;
using Task3.ATS.Ports;

namespace Task3.Terminals.TerminalImplementation
{
    class Terminal : ITerminal
    {
        private bool isOn;

        public TerminalStatus Status
        {
            get
            {
                if (isOn)
                {
                    return TerminalStatus.PowerOn;
                }
                else
                {
                    return TerminalStatus.PowerOff;
                }
            }

            private set
            {
                if(value == TerminalStatus.PowerOff)
                {
                    isOn = false;
                }
                else
                {
                    isOn = true;
                }
            }
        }

        public IPort Port { get; private set; }

        public Terminal()
        {
            Status = TerminalStatus.PowerOn;
        }

        public TerminalStatus Call(string number)
        {
            if(isOn)
            {
                Port.ConnectToNumber(number);
                return TerminalStatus.OperationSuccess;
            }
            else
            {
                return Status;
            }
            
        }

        public TerminalStatus Decline()
        {
            if (isOn)
            {
                Port.EndCall();
                return TerminalStatus.OperationSuccess;
            }
            else
            {
                return Status;
            }
        }

        public TerminalStatus PowerOn()
        {
            this.Status = TerminalStatus.PowerOn;
            return Status;
        }

        public TerminalStatus PowerOff()
        {
            this.Status = TerminalStatus.PowerOff;
            return Status;
        }

        public TerminalStatus AddPort(IPort port)
        {
            if(isOn)
            {
                if (port != null)
                {
                    this.Port = port;
                    this.Port.IncomingCall += OnIncomingCall;
                    return TerminalStatus.OperationSuccess;
                }
                else
                {
                    return TerminalStatus.OperationError;
                }
            }
            else
            {
                return Status;
            }
        }

        public TerminalStatus RemovePort()
        {
            this.Port = null;
            return TerminalStatus.OperationSuccess;
        }

        private void OnIncomingCall(object sender, string number)
        {
            Console.WriteLine("Terminal with port {0} incoming call from {1}", Port.Number, number);
        }
    }
}
