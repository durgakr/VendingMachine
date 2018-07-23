using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IAccountRepo
    {
        decimal GetAccountBalance(int accNumber);
        bool UpdateAccount(int accNumber);
    }
}
