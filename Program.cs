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
using Task3.Users.UserImplementation;
using Task3.Billing.Accounts.AccountImplementation;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating station and terminals
            Station stantion = new Station();
            Terminal terminal1 = new Terminal();
            Terminal terminal2 = new Terminal();

            //Creating user 1
            User user1 = new User("Vladislav", "Ivanov", terminal1);
            Account acc1 = new Account(user1);
            acc1.AddFounds(10);
            user1.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375298005544"));
            Console.WriteLine(acc1.ActivateAccount());

            //Creating user 2
            User user2 = new User("Kirill", "Nekrasov", terminal2);
            Account acc2 = new Account(user2);
            acc2.AddFounds(10);
            user2.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375291234567"));
            Console.WriteLine(acc2.ActivateAccount());

            Console.WriteLine(stantion.Status);

            //Calling user 2 from user 1
            Console.WriteLine(user1.Terminal.Call("+375291234567"));

            //Checking balance
            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);

            Console.WriteLine(terminal1.Port.Status + " " + terminal2.Port.Status);

            //Ending call
            user1.Terminal.Decline();

            Console.WriteLine(terminal1.Port.Status);
            Console.WriteLine(terminal2.Port.Status);

            Console.WriteLine("");
            Console.WriteLine("Output log1:");
            Console.WriteLine(acc1.GetAccountLog());

            Console.WriteLine("");
            Console.WriteLine("Output log2:");
            Console.WriteLine(acc2.GetAccountLog());

            Console.WriteLine(user1.Terminal.PowerOff());
            Console.WriteLine(user1.Terminal.Call("+375291234567"));
            Console.WriteLine(user1.Terminal.PowerOn());

            Console.ReadKey();
        }
    }
}
