using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;
using Task3.Billing.Accounts.AccountImplementation;

namespace Task3.Billing.Accounts
{
    interface IAccount
    {
        Balance AccountBalance { get; }
        string AddFounds(float sum);

        string GetAccountLog();
        AccountStatus ActivateAccount();
        AccountStatus Status { get; }
    }
}
