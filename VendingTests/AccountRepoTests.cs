using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingTests
{
    [TestClass]
    public class AccountRepoTests
    {
        IAccountRepo accountRepo;
        [TestInitialize]
        public void Init()
        {
            var accList = new List<Account>();
            accList.Add(new Account { AccountNumber = 1234, Balance = 20 });
            accList.Add(new Account { AccountNumber = 2345, Balance = 10 });
            accountRepo = new AccountRepo(accList);
        }

        [TestMethod]
        public void GetAccountBalance_ValidAccount_Returns_NonZeroValue()
        {
            // Act
            var accBalance = accountRepo.GetAccountBalance(1234);

            // Assert
            Assert.AreEqual(20m, accBalance);
        }

        [TestMethod]
        public void GetAccountBalance_InvalidAccount_Returns_Zero()
        {
            // Act
            var accBalance = accountRepo.GetAccountBalance(5555);

            // Assert
            Assert.AreEqual(0m, accBalance);
        }
    }
}
