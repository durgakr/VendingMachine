using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingTests
{
    [TestClass]
    public class CashCardRepoTests
    {
        CashCardRepo cashCardRepo;
        [TestInitialize]
        public void Init()
        {            
            var cashCards = new List<CashCard>();
            cashCards.Add(new CashCard { AccountNumber = 1234, CardNumber = 9876, Pin = 9999 });
            cashCards.Add(new CashCard { AccountNumber = 1234, CardNumber = 3456, Pin = 8888 });
            cashCardRepo = new CashCardRepo(cashCards);            
        }
        [TestMethod]
        public void IsAuthorised_Positive_Returns_True()
        {
            // Act
            var isAuth = cashCardRepo.IsAuthorised(9876, 9999);

            // Assert
            Assert.IsTrue(isAuth);
        }
        [TestMethod]
        public void IsAuthorised_Negative_Returns_False()
        {
            // Act
            var isAuth = cashCardRepo.IsAuthorised(3456, 9999);

            // Assert
            Assert.IsFalse(isAuth);
        }
    }
}
