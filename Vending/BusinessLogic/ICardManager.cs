using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface ICardManager
    {
        bool IsAuthorised(CashCard cashCard, int PinNumber);
    }
}
