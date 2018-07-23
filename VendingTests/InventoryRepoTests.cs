using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingTests
{
    [TestClass]
    public class InventoryRepoTests
    {
        InventoryRepo inventoryRepo;
        [TestInitialize]
        public void Init()
        {
            Inventory inventory = new Inventory();
            inventoryRepo = new InventoryRepo(inventory);
            
        }
        [TestMethod]
        public void GetCount_Returns_25()
        {
            //Act
            var maxCount = inventoryRepo.GetCount();

            // Assert
            Assert.AreEqual(25, maxCount);

        }
    }
}
