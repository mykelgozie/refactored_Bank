using bankapp_refactored_week4.BankLibs;
using bankapp_refactored_week4.datas;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace refactored_Test
{

    [TestFixture]
    public class Tests
    {
        public string Email { get; private set; }
        public string  Name { get; private set; }
        public string Password { get; private set; }
        public int Acctype { get; private set; }
        public string Note { get; private set; }

        [SetUp]
        public void Setup()
        {
            Email = "bola@gmail.com";
            Name = "bola";
            Password = "12345";
            Acctype = 0;
            Note = "Transfer";

        }

        // test case for resgitration
        [Test]
        public void Register()
        {

            //user account is null
            AccountClass account = null;

            //Register user and return user account 
            account = AuthClass.Register(Name, Email, Password, Acctype);

           // test if account was registered 
            Assert.That(account, Is.Not.Null);

        }

      
        [Test]
        public void RegisterFail()
        {
            //user account is null
            AccountClass account = null;
            // make user empty
            Name = "";

            //Register user and return user account 
            account = AuthClass.Register(Name, Email, Password, Acctype);

            Assert.That(account, Is.Null);

        }


        
        // test case for login
        [Test]
        public void Login()
        {
            // make login Null
            AccountClass loginAcct = null;

            //register  new user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);

            //login user 
            loginAcct = AuthClass.Login(Email, Password);

            // test if login returns user 
            Assert.That(loginAcct, Is.Not.Null);

        }

        

        // test for Invalid 
        [Test]
        public void LoginFail()
        {
            //assign login variables 
             Email = "non@gmail.com";
             Password = "12345";
             AccountClass loginAcct = null;

            //login user 
            loginAcct = AuthClass.Login(Email, Password);

            // test if login returns user 
            Assert.That(loginAcct, Is.Null);
        }


       
        // test case for Deposit
        [Test]
        public void MakeDeposit()
        {
           // amt to deposit
            decimal amtDeposit = 5000;

            // register user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // user account balance 
            var balance = account.Balance;
            // deposit money to user account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, Note, account.AccountType);

            // Expected amount
            decimal expectedAmt = balance + amtDeposit;

            // test account for increment by amount deposited 
            Assert.That(account.Balance, Is.EqualTo(expectedAmt));

        }

       
        [Test]
        public void MakeDepositFail()
        {
            // amount to deposit
            decimal amtDeposit = -5000;
            // register user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            
            // deposit money to user account  Act & Assert

            Assert.That(
                () => account.MakeDeposit(account.AccountNumber, amtDeposit, Note, account.AccountType),
                Throws.TypeOf<System.ArgumentOutOfRangeException>()
                );

        }

       

        // test case for account withdrawal
        [Test]
        public void MakeWithdrawal()
        {
            // amount to deposit
            decimal amtDeposit = 5000;
            string note = "withdraw money";
            // register user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // deposit money into account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, note, account.AccountType);
            // user account balance
            var balance = account.Balance;
            // amount to withdraw from account 
            decimal amtWithdraw = 1000;
            // withdraw from user account
            account.MakeWithdrawal(account.AccountNumber, amtWithdraw, note, account.AccountType);
            // expected Amount
            decimal expectedAmt = balance - amtWithdraw;
            // test user account for decrement by the amount withdraw
            Assert.That(account.Balance, Is.EqualTo(expectedAmt));

        }

        
        [Test]

        public void MakeWithdrawalFail()
        {
            // user details 
            // amount to deposit
            decimal amtDeposit = 500;
            // register user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // deposit money into account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, Note, account.AccountType);
            // user account balance
            var balance = account.Balance;
            // amount to withdraw from account 
            decimal amtWithdraw = 1000;
            // withdraw from user account

            Assert.That(
                () => account.MakeWithdrawal(account.AccountNumber, amtWithdraw, Note, account.AccountType),
                Throws.TypeOf<System.ArgumentOutOfRangeException>()
                );

        }
       

        [Test]
        public void MakeTransfer()
        {
        
            // amount to deposit to 1st user account 
            decimal amt = 5000;
           // string note = "withdraw money";
            // regsiter 1st user  
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // Deposit Money into 1st user acount
            account.MakeDeposit(account.AccountNumber, amt, Note, account.AccountType);
            // 1st user account balance 
            var balance = account.Balance;

            // 2nd user details.
            string email2 = "john@gmail.com";
            string name2 = "john";
            string password2 = "12345";
            int acctype2 = 0;
            //Register 2nd user and return 2nd user account 
            AccountClass account2 = AuthClass.Register(name2, email2, password2, acctype2);
            // amount to tranfer 
            decimal amtTransfer = 1000;
            // Transfer money from 1st to 2nd account 
            account.MakeTransfer(account.AccountNumber, amtTransfer, Note, account.AccountType, account2);
            // test for transfer 
            Assert.That(account.Balance, Is.EqualTo(balance - amtTransfer));


        }

        [Test]
        public void MakeTransferFail()
        {
            decimal amt = 5000;
            // string note = "withdraw money";
            // regsiter 1st user  
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // Deposit Money into 1st user acount
            account.MakeDeposit(account.AccountNumber, amt, Note, account.AccountType);
            // 1st user account balance 
            var balance = account.Balance;

            // 2nd user details.
            string email2 = "john@gmail.com";
            string name2 = "john";
            string password2 = "12345";
            int acctype2 = 0;
            //Register 2nd user and return 2nd user account 
            AccountClass account2 = AuthClass.Register(name2, email2, password2, acctype2);
            // amount to tranfer 
            decimal amtTransfer = 10000;
           
           
            // test for transfer 

            Assert.That(
              () => account.MakeTransfer(account.AccountNumber, amtTransfer, Note, account.AccountType, account2),
              Throws.TypeOf<System.ArgumentOutOfRangeException>()
              );

        }

        [Test]
        public void Transactions()
        {

           
            // amount to deposit
            decimal amtDeposit = 5000;
            // number of trasactions 
            int count = BankdatasClass.Transactions.Count;
            // register user 
            AccountClass account = AuthClass.Register(Name, Email, Password, Acctype);
            // deposit money into account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, Note, account.AccountType);
            // new count 
            int newCount = BankdatasClass.Transactions.Count;
            int expected = count + 1;

            Assert.That(newCount, Is.EqualTo(expected));



        }


        ///
        ///
        ///
        ///
        ////

        [Test]
        public void TransactionsFail()
        {

            // user details 
            string email = "bola@gmail.com";
            string name = "bola";
            string password = "12345";
            int acctype = 0;
            // amount to deposit
            decimal amtDeposit = -5000;
            string note = "withdraw money";
            // number of trasactions 
            int count = BankdatasClass.Transactions.Count;
            // register user 
            AccountClass account = AuthClass.Register(name, email, password, acctype);

            // deposit money into account 
            Assert.That(
                () => account.MakeDeposit(account.AccountNumber, amtDeposit, Note, account.AccountType),
                Throws.TypeOf<System.ArgumentOutOfRangeException>()
                );


        }
    }
}