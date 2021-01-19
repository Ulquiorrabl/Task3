using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Users;
using Task3.Statuses;
using Task3.Billing.Accounts.AccountLogs;

namespace Task3.Billing.Accounts.AccountImplementation
{
    class Account : IAccount
    {
        public float Balance { get; private set; }

        public float Cost = 1.5f;

        public AccountStatus Status { get; private set; }

        private AccountLog accountLog;

        IUser owner;
        public Account(IUser owner)
        {
            this.owner = owner;
            this.Balance = 0;
            accountLog = new AccountLog();
            Status = AccountStatus.Deactivated;
            ActivateAccount();
        }

        public AccountStatus ActivateAccount()
        {
            if (owner.Terminal.Port != null)
            {
                owner.Terminal.Port.Call += OutGoingCall;
                owner.Terminal.Port.IncomingCall += OnIncomingCall;
                Status = AccountStatus.Activated;
                return AccountStatus.Activated;
            }
            else
            {
                return AccountStatus.Deactivated;
            }
        }

        public string GetAccountLog()
        {
            return accountLog.ToString();
        }

        public string AddFounds(float sum)
        {
            if(sum > 0)
            {
                Balance += sum;
            }
            accountLog.AddLog("Founds added " + sum.ToString() + "$ " + DateTime.Now);
            return "Current balance: " + Balance.ToString();
        }

        void OutGoingCall(object sender, string number)
        {
            float cost = Cost;
            Balance -= cost;
            accountLog.AddLog("Call to " + number + " " + DateTime.Now);
            accountLog.AddLog("Call cost: " + cost.ToString() + "$" + " Account Balance: " + Balance.ToString() + "$");
        }

        void OnIncomingCall(object sender, string number)
        {
            accountLog.AddLog("Call from " + sender.ToString() + " " + DateTime.Now);
        }
    }
}
