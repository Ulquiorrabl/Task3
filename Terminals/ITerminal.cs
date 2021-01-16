using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;
using Task3.ATS.Ports;

namespace Task3.Terminals
{
    interface ITerminal
    {
        TerminalStatus Status { get; }
        TerminalStatus Call(string number);
        TerminalStatus Decline();
        TerminalStatus Answer();
        TerminalStatus PowerOn();
        TerminalStatus PowerOff();
        TerminalStatus AddPort(IPort port);

    }
}
