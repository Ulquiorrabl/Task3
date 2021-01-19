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
            Console.WriteLine("Creating user 1");
            User user1 = new User("Vladislav", "Ivanov", terminal1);
            Account acc1 = new Account(user1);
            acc1.AddFounds(15);
            user1.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375298005544"));
            Console.WriteLine(acc1.ActivateAccount());
            Console.WriteLine("");

            //Creating user 2
            Console.WriteLine("Creating user2");
            User user2 = new User("Kirill", "Nekrasov", terminal2);
            Account acc2 = new Account(user2);
            acc2.AddFounds(27);
            user2.Terminal.AddPort(stantion.GeneratePort(Region.Region1, "+375291234567"));
            Console.WriteLine(acc2.ActivateAccount());
            Console.WriteLine("");

            Console.WriteLine("ATS Status:");
            Console.WriteLine(stantion.Status);
            Console.WriteLine("");

            //Calling user 1 from user 2
            Console.WriteLine("Calling from user 1 to user 2");
            Console.WriteLine(user1.Terminal.Call("+375291234567"));
            Console.WriteLine("");

            //Checking balance
            Console.WriteLine("Balance for users 1 and 2");
            Console.WriteLine("User 1 account balance: {0}", acc1.AccountBalance);
            Console.WriteLine("User 2 account balance: {0}", acc2.AccountBalance);
            Console.WriteLine("");

            Console.WriteLine("User's ports statuses:");
            Console.WriteLine(terminal1.Port.Status + " " + terminal2.Port.Status);
            Console.WriteLine("");

            //Ending call
            System.Threading.Thread.Sleep(6000);
            Console.WriteLine("Ending call");
            user1.Terminal.Decline();
            Console.WriteLine("");

            Console.WriteLine("User's ports statuses:");
            Console.WriteLine(terminal1.Port.Status);
            Console.WriteLine(terminal2.Port.Status);
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("Output log for user 1:");
            Console.WriteLine(acc1.GetAccountLog());
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("Output log for user 2:");
            Console.WriteLine(acc2.GetAccountLog());
            Console.WriteLine("");

            Console.WriteLine("Turning off power for user 1 terminal");
            Console.WriteLine(user1.Terminal.PowerOff());
            Console.WriteLine("Trying to call...");
            Console.WriteLine(user1.Terminal.Call("+375291234567"));
            Console.WriteLine("Turning on power for user 1 terminal");
            Console.WriteLine(user1.Terminal.PowerOn());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
