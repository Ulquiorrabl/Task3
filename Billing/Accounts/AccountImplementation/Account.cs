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
        public Balance AccountBalance { get; private set; }

        public float CostPerMinute = 1.5f;

        public AccountStatus Status { get; private set; }

        private AccountLog accountLog;

        private bool isCallInitiator;

        IUser owner;
        public Account(IUser owner)
        {
            this.owner = owner;
            this.isCallInitiator = false;
            this.AccountBalance = new Balance();
            accountLog = new AccountLog();
            Status = AccountStatus.Deactivated;
            ActivateAccount();
        }

        public AccountStatus ActivateAccount()
        {
            if (owner.Terminal.Port != null)
            {
                owner.Terminal.Port.Call += OnOutGoingCall;
                owner.Terminal.Port.IncomingCall += OnIncomingCall;
                owner.Terminal.Port.CallEnded += OnCallEnded;
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
                AccountBalance.Add(sum);
            }
            accountLog.AddLog(DateTime.Now + " Founds added " + sum.ToString() + "$ ");
            return "Current balance: " + AccountBalance;
        }

        void OnOutGoingCall(object sender, string number)
        {
            isCallInitiator = true;
            accountLog.AddCallDate(DateTime.Now);
            //accountLog.AddLog("Call to " + number + " " + DateTime.Now);
            //accountLog.AddLog("Call cost: " + cost.ToString() + "$" + " Account Balance: " + Balance.ToString() + "$");
        }

        void OnIncomingCall(object sender, string number)
        {
            accountLog.AddLog(DateTime.Now + " Call from " + sender.ToString());
        }

        void OnCallEnded(object sender, string number)
        {
            if (isCallInitiator)
            {
                double diff = ((DateTime.Now - accountLog.LastInitiatedCallDate).TotalSeconds /60);
                TimeSpan timeDiff = DateTime.Now - accountLog.LastInitiatedCallDate;
                double totalCost = diff * CostPerMinute;
                AccountBalance.Remove(diff * CostPerMinute);
                accountLog.AddLog(accountLog.LastInitiatedCallDate + " Call to " + number + " lasted " + timeDiff + " Total cost: " + totalCost + "$" + " Balance: " + AccountBalance);
                isCallInitiator = false;
            }
        }
    }
}
