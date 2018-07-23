using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class AccountManager : IAccountManager
    {
        IAccountRepo _accountRepo;
        public AccountManager(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public Task<bool> DoesAccountHaveBalance(CashCard cashCard)
        {
            var result = _accountRepo.GetAccountBalance(cashCard.AccountNumber);
            if (result >= 0.5m)
                return Task.FromResult<bool>(true);
            else
                return Task.FromResult<bool>(false);

        }      

        public bool UpdateAccount(CashCard card)
        {
            throw new NotImplementedException();
        }
    }
}
