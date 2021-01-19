using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Task3.Terminals;

namespace Task3.Users
{
    interface IUser
    {
        string Name { get; }
        string Surname { get; }
        ITerminal Terminal { get; }
    }
}