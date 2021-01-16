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
        public TerminalStatus Status { get; private set; }

        private IPort port;

        public Terminal()
        {
            Status = TerminalStatus.PowerOn;
        }

        public TerminalStatus Call(string number)
        {
            throw new NotImplementedException();
        }

        public TerminalStatus Decline()
        {
            throw new NotImplementedException();
        }

        public TerminalStatus Answer()
        {
            throw new NotImplementedException();
        }

        public TerminalStatus PowerOn()
        {
            this.Status = TerminalStatus.PowerOn;
            return TerminalStatus.PowerOn;
        }

        public TerminalStatus PowerOff()
        {
            this.Status = TerminalStatus.PowerOff;
            return TerminalStatus.PowerOff;
        }

        public TerminalStatus AddPort(IPort port)
        {
            if(port != null)
            {
                this.port = port;
                return TerminalStatus.OperationSuccess;
            }
            else
            {
                return TerminalStatus.OperationError;
            }
        }
    }
}
