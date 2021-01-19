using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Terminals;

namespace Task3.Users.UserImplementation
{
    class User : IUser
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public ITerminal Terminal { get; private set; }

        public User(string name, string surname, ITerminal terminal = null)
        {
            this.Name = name;
            this.Surname = surname;
            this.Terminal = terminal;
        }
    }
}
