using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class InventoryRepo: IInventoryRepo
    {
        Inventory _inventory;
        public InventoryRepo(Inventory inventory)
        {
            _inventory = inventory;
            // Initialise to 25
            _inventory.count = Int32.Parse(ConfigurationManager.AppSettings["MaxInventoryCount"]);
                
        }
        public int GetCount()
        {
            return _inventory.count;
            
        }

        public bool UpdateInventory()
        {
            if (_inventory.count == 0)
                return false;
            else
            {
                _inventory.count--;
                return true;

            }      

        }
    }
}
