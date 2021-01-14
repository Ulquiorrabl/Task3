using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Terminals;

namespace Task3.Users
{
    class User
    {
        string name;
        string surname;
        ITerminal terminal;

        public User(string name, string surname, ITerminal terminal = null)
        {
            this.name = name;
            this.surname = surname;
            this.terminal = terminal;
        }
    }
}
