using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class AccountRepo : IAccountRepo
    {
        List<Account> _accList;
        public AccountRepo(List<Account> accList)
        {
            _accList = accList.ToList();
        }
        public decimal GetAccountBalance(int accNumber)
        {
            var account = _accList.Where(a => a.AccountNumber == accNumber).FirstOrDefault();
            if (account != null)
                return account.Balance;
            else
                return 0;

        }

        public bool UpdateAccount(int accNumber)
        {
            lock(_accList)
            {
                var account = _accList.Where(a => a.AccountNumber == accNumber).FirstOrDefault();
                if (account != null)
                {
                    account.Balance -= 0.5m;
                    return true;
                }
                else
                    // No records to update
                    return false;
            }            

        }

    }
}
