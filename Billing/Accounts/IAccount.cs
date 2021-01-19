using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;

namespace Task3.Billing.Accounts
{
    interface IAccount
    {
        float Balance { get; }
        string AddFounds(float sum);

        string GetAccountLog();
        AccountStatus ActivateAccount();
        AccountStatus Status { get; }
    }
}
