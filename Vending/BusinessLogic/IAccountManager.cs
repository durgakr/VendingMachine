using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IAccountManager
    {
        Task<bool> DoesAccountHaveBalance(CashCard cashCard);      
        bool UpdateAccount(CashCard card);
    }
}
