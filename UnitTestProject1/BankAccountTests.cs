using System;
using Bank_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()

        {
            //Arrange
            double beginningBalance = 11.99;
            double DebitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //Act
            account.Debit(DebitAmount);

            //Assert 
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr.Bryan Walton", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert is handled by the expectedException attribute on the test method.

        }
        [TestMethod]
        
        public void Debit_WhenAmountIsMoreThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr.Bryan Walton", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert is handled by the expectedException attribute on the test method.

        }
        [TestMethod]
        public void Debit_WhenAmountIsThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr.Bryan Walton", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr.Bryan Walton", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedbalanceMessage);
                return;
            }
            Assert.Fail("Expected expection not thrown");
        }
    }

}
