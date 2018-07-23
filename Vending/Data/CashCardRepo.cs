using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class CashCardRepo: ICashCardRepo
    {
        List<CashCard> _cashCards;
        public CashCardRepo(List<CashCard> cashCards)
        {
            _cashCards = cashCards.ToList();           
        }

        public bool IsAuthorised(int cardNumber, int pin)
        {
            return _cashCards.Where(cc => cc.CardNumber == cardNumber && cc.Pin == pin).Count() == 1;
        }
    }
}
