using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Terminals.TerminalImplementation
{
    class Terminal : ITerminal
    {
        public int Id { get; private set; }

        public Terminal(int id)
        {
            this.Id = id;
        }
    }
}
