using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class CardManager: ICardManager
    {
        ICashCardRepo _cashCardRepo;
        CardManager(ICashCardRepo cashCardRepo)
        {
            _cashCardRepo = cashCardRepo;
        }
        public bool IsAuthorised(CashCard cashCard, int pin)
        {
           return _cashCardRepo.IsAuthorised(cashCard.CardNumber, pin);
        }
    }
}
