using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class InventoryManager : IInventoryManager
    {
        IInventoryRepo _inventoryRepo;
        public InventoryManager(IInventoryRepo inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }
        public Task<bool> IsVendingPossible()
        {
           return Task.FromResult<bool>(_inventoryRepo.GetCount() > 0);
        }

        public bool UpdateInventory()
        {
            return _inventoryRepo.UpdateInventory();
        }
    }
}
