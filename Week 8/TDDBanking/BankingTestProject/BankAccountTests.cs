// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Transactions;
using BankingTDD.Models;
using System.Collections;

namespace BankingTestProject
{
    public class BankAccountTests
    {
        //A class property that provides test data
        public static IEnumerable<object[]> WithdrawalData =>
            new List<object[]>
        {
           new object[] { "0234567890", "John Doe",5000, -2000, 3000},
           new object[] { "0234567890", "John Doe",7854.45, -5784.54, 1799.91},
           new object[] { "0234567890", "John Doe",45874, -2545.45, 43328.55},
           new object[] { "0234567890", "John Doe",43328.55, -24583.48, 18745.07}
        };

        [Theory]
        [MemberData(nameof(WithdrawalData))]

        public void MakeWithdrawal_ValidAmounts_ChangesBalance3(string accNum, string owner, decimal startingBalance,
           decimal withdrawalAmount, decimal expectedBalance)
        {
            //This unit test illustrates how to use a test class
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount(accNum, owner, startingBalance);
            decimal expected = expectedBalance;

            //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }

        [Theory]
        [MemberData(nameof(GetWithdrawalTestData), parameters:3)]

        public void MakeWithdrawal_ValidAmounts_ChangesBalance4(string accNum, string owner, decimal startingBalance,
          decimal withdrawalAmount, decimal expectedBalance)
        {
            //This unit test illustrates how to use test data from a method of the test class
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount(accNum, owner, startingBalance);
            decimal expected = expectedBalance;

            //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }

        public static IEnumerable<object[]> GetWithdrawalTestData(int numTest)
        {
            var testData = new List<object[]>
            {
                new object[] { "0234567890", "John Doe",5000, -2000, 3000},
                new object[] { "0234567890", "John Doe",7854.45, -5784.54, 2069.91},
                new object[] { "0234567890", "John Doe",45874, -2545.45, 43328.55},
                new object[] { "0234567890", "John Doe",43328.55, -24583.48, 18745.07}
            };

            return testData.Take(numTest);
        }


        [Fact]
        public void MakeWithdrawal_ValidAmount_ChangesBalance()
        {
            /// The MakeWithdrawal adds a new Transaction to the account with the given amount and note. We 
            /// should check that the withdrawal amount does not exceed the account balance. If it does throw
            /// an argument exception.
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount("0234567890", "John Doe", 10.0m);
            decimal expected = 9.0m;
            decimal withdrawalAmount = -1.0m;
                //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }

        [Theory]
        [InlineData("0234567890", "John Doe", 40, -20, 20)]
        [InlineData("0234567890", "John Doe", 25, -25, 0)]
        [InlineData("0234567890", "John Doe", 100, -80, 20)]
        [InlineData("0234567890", "John Doe", 400, -250, 150)]
        public void MakeWithdrawal_ValidAmounts_ChangesBalance(string accNum, string owner, decimal startingBalance,
            decimal withdrawalAmount, decimal expectedBalance)
        {
            /// The MakeWithdrawal adds a new Transaction to the account with the given amount and note. We 
            /// should check that the withdrawal amount does not exceed the account balance. If it does throw
            /// an argument exception.
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount(accNum, owner, startingBalance);
            decimal expected = expectedBalance;
            
            //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }


        [Fact]
        public void MakeWithdrawal_InValidAmount_BalanceUnchanged()
        {
            /// The MakeWithdrawal adds a new Transaction to the account with the given amount and note. We 
            /// should check that the withdrawal amount does not exceed the account balance. If it does throw
            /// an argument exception.
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount("0234567890", "John Doe", 10.0m);
            decimal withdrawalAmount = -20.0m;
            decimal expected = 10.0m;
           
            //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }

        [Fact]
        public void MakeWithdrawal_InValidAmount_ThrowsException()
        {
            /// The MakeWithdrawal adds a new Transaction to the account with the given amount and note. We 
            /// should check that the withdrawal amount does not exceed the account balance. If it does throw
            /// an argument exception.
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount("0234567890", "John Doe", 10.0m);
            decimal withdrawalAmount = -20.0m;
            

            //Act 
            //Assert.Throws<ArgumentException>(() => testAccount.MakeWithdrawal(withdrawalAmount,                DateTime.Now, "Test Withdrawal"));
            var exception = Record.Exception(() => testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal"));


            //Assert - assert that the state of the system under test (SUT) is as expected
            //Assert.Equal(expected, testAccount.Balance, 2);
            Assert.IsType<ArgumentException>(exception);
        }

        [Theory]
        [ClassData(typeof(WithdrawalTestDataClass))]
       
        public void MakeWithdrawal_ValidAmounts_ChangesBalance2(string accNum, string owner, decimal startingBalance,
           decimal withdrawalAmount, decimal expectedBalance)
        {
            //This unit test illustrates how to use a test class
            //Arrange - arrange the data needed for the test
            BankAccount testAccount = new BankAccount(accNum, owner, startingBalance);
            decimal expected = expectedBalance;

            //Act - execute the functionality we need to test
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test Withdrawal");

            //Assert - assert that the state of the system under test (SUT) is as expected
            Assert.Equal(expected, testAccount.Balance, 2);
        }

    }
}

public class WithdrawalTestDataClass : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {

        yield return new object[] { "0234567890", "John Doe", 40, -20, 20 };
        yield return new object[] { "0234567890", "John Doe", 25, -25, 0 };
        yield return new object[] { "0234567890", "John Doe", 100, -80, 20 };
        yield return new object[] { "0234567890", "John Doe", 500, -200, 300 };


    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
