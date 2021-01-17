using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Users;
using Task3.Terminals;
using Task3.Terminals.TerminalImplementation;
using Task3.ATS;
using Task3.ATS.Regions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stantion stantion = new Stantion();
            Terminal terminal1 = new Terminal();
            Terminal terminal2 = new Terminal();
            User user1 = new User("Vladislav", "Ivanov", terminal1);
            user1.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375298005544"));
            User user2 = new User("Kirill", "Nekrasov", terminal2);
            user2.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375291234567"));
            Console.WriteLine(stantion.Status);
            Console.WriteLine(user1.Terminal.Call("+375291234567"));
            Console.ReadKey();
        }
    }
}
