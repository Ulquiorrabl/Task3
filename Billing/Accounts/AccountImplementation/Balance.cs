using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Billing.Accounts.AccountImplementation
{
    class Balance
    {
        private double balance;

        public Balance()
        {
            balance = 0;
        }

        public void Remove(double sum)
        {
            balance -= sum;
        }
        public void Add(double sum)
        {
            balance += sum;
        }
        public override string ToString()
        {
            return balance + "$";
        }
    }
}
