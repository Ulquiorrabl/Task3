using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;

namespace Task3.Billing.Accounts.AccountLogs
{
    class AccountLog
    {
        private StringBuilder log = new StringBuilder();

        public DateTime LastInitiatedCallDate { get; private set; }
        public AccountLogStatus AddLog(string line)
        {
            log.Append(line + "\n");
            return AccountLogStatus.LogAdded;
        }
        public override string ToString()
        {
            return log.ToString();
        }

        public AccountLogStatus AddCallDate(DateTime callDate)
        {
            LastInitiatedCallDate = callDate;
            return AccountLogStatus.LogAdded;
        }
    }
}
