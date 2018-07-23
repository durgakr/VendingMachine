using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine;

namespace VendingTests
{
    [TestClass]
    public class VendingUnitTests
    {
        Vending vending;        
        Mock<IInventoryManager> mockInventoryManager;
        Mock<IAccountManager> mockAccountManager;
        Mock<ICardManager> mockCardManager;


        [TestInitialize]
        public void Init()
        {
            mockInventoryManager = new Mock<IInventoryManager>();            
            mockAccountManager = new Mock<IAccountManager>();
            mockCardManager = new Mock<ICardManager>();
            vending = new Vending(mockInventoryManager.Object, mockAccountManager.Object, mockCardManager.Object);
        }

        [TestMethod]
        public void VendAsync_Positive_Returns_True()
        {
            // Arrange
            var cashCard = new CashCard { AccountNumber = 1234, CardNumber = 9876 };
            mockCardManager.Setup(mcm => mcm.IsAuthorised(cashCard,9999)).Returns(true);
            mockAccountManager.Setup(mam => mam.DoesAccountHaveBalance(cashCard)).Returns(Task.FromResult<bool>(true));
            mockInventoryManager.Setup(mim => mim.IsVendingPossible()).Returns(Task.FromResult<bool>(true));
            mockInventoryManager.Setup(mim => mim.UpdateInventory()).Returns(true);
            mockAccountManager.Setup(mam => mam.UpdateAccount(cashCard)).Returns(true);

            // Act

            var vendingResult = vending.Vend(cashCard, 9999).Result;

            // Assert
            Assert.IsTrue(vendingResult);


        }

        [TestMethod]
        public void VendAsync_IncorrectPin_Returns_False()
        {
            // Arrange
            var cashCard = new CashCard { AccountNumber = 1234, CardNumber = 9876 };
            mockCardManager.Setup(mcm => mcm.IsAuthorised(cashCard, 9999)).Returns(false);

            // Act

            var vendingResult = vending.Vend(cashCard, 9999).Result;

            // Assert
            Assert.IsFalse(vendingResult);
        }

        [TestMethod]
        public void VendAsync_InsufficientInventory_Returns_False()
        {
            // Arrange
            var cashCard = new CashCard { AccountNumber = 1234, CardNumber = 9876 };
            mockCardManager.Setup(mcm => mcm.IsAuthorised(cashCard, 9999)).Returns(true);
            mockAccountManager.Setup(mam => mam.DoesAccountHaveBalance(cashCard)).Returns(Task.FromResult<bool>(true));
            mockInventoryManager.Setup(mim => mim.IsVendingPossible()).Returns(Task.FromResult<bool>(false));
           
            // Act

            var vendingResult = vending.Vend(cashCard, 9999).Result;

            // Assert
            Assert.IsFalse(vendingResult);
        }

        [TestMethod]
        public void VendAsync_InsufficientBalance_Returns_False()
        {
            // Arrange
            var cashCard = new CashCard { AccountNumber = 1234, CardNumber = 9876 };
            mockCardManager.Setup(mcm => mcm.IsAuthorised(cashCard, 9999)).Returns(true);
            mockAccountManager.Setup(mam => mam.DoesAccountHaveBalance(cashCard)).Returns(Task.FromResult<bool>(false));
            mockInventoryManager.Setup(mim => mim.IsVendingPossible()).Returns(Task.FromResult<bool>(true));

            // Act

            var vendingResult = vending.Vend(cashCard, 9999).Result;

            // Assert
            Assert.IsFalse(vendingResult);
        }
    }
}
