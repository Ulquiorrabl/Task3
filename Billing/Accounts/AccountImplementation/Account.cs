using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Users;
using Task3.Statuses;

namespace Task3.Billing.Accounts.AccountImplementation
{
    class Account : IAccount
    {
        public float Balance { get; private set; }

        public float Cost = 1.5f;

        public AccountStatus Status { get; private set; }

        IUser owner;
        public Account(IUser owner)
        {
            this.owner = owner;
            this.Balance = 0;
            Status = AccountStatus.Deactivated;
            ActivateAccount();
        }

        public AccountStatus ActivateAccount()
        {
            if (owner.Terminal.Port != null)
            {
                owner.Terminal.Port.Call += OutGoingCall;
                Status = AccountStatus.Activated;
                return AccountStatus.Activated;
            }
            else
            {
                return AccountStatus.Deactivated;
            }
        }

        public string AddFounds(float sum)
        {
            if(sum > 0)
            {
                Balance += sum;
            }         
            return "Current balance: " + Balance.ToString();
        }

        void OutGoingCall(object sender, string number)
        {
            Balance -= 1.0f;
        }
    }
}
