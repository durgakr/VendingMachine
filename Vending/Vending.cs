using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Vending
    {
        IInventoryManager _inventoryManager;
        IAccountManager _accountManager;
        ICardManager _cardManager;

        public Vending(IInventoryManager inventoryManager, IAccountManager accountManager, ICardManager cardManager)
        {
            _inventoryManager = inventoryManager;
            _accountManager = accountManager;
            _cardManager = cardManager;
        }

        public Task<bool> Vend(CashCard cashCard, int PinNumber)
        {
            var isVendingSuccess = false;
            // No point proceeding if PIN is incorrect
            if (_cardManager.IsAuthorised(cashCard, PinNumber))
            {
                var isVendingPossible = _inventoryManager.IsVendingPossible();
                var doesAccHaveBalance = _accountManager.DoesAccountHaveBalance(cashCard);
                

                if (isVendingPossible.Result && doesAccHaveBalance.Result)
                {
                    var updateAccount = _accountManager.UpdateAccount(cashCard);
                    var updateInventory = _inventoryManager.UpdateInventory();
                    if (updateAccount && updateInventory)
                        isVendingSuccess = true;
                }
                

            }

            return Task.FromResult<bool>(isVendingSuccess);
            
        }
    }
}
