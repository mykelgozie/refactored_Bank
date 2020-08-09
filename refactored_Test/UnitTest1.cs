using bankapp_refactored_week4.BankLibs;
using bankapp_refactored_week4.datas;
using NUnit.Framework;



namespace refactored_Test
{

    [TestFixture]
    public class Tests
    {
        // test case for resgitration
        [Test]
        public void Register()
        {   
            //user account is null
            AccountClass account = null;

            //assign register details  
            string email = "mike@gmail.com";
            string name = "michael";
            string password = "12345";
            int acctype = 0;

            //Register user and return user account 
            account = AuthClass.Register(name, email, password, acctype);

           // test if account was registered 
            Assert.That(account, Is.Not.Null);

        }

        // test case for login
        [Test]
        public void Login()
        {
            //assign login variables 
            string email = "nonso@gmail.com";
            string name = "Nonso";
            string password = "12345";
            int acctype = 0;

            //register  new user 
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            AccountClass loginAcct = null;

            //login user 
            loginAcct = AuthClass.Login(email,password);

            // test if login returns user 
            Assert.That(loginAcct, Is.Not.Null);



        }

        // test case for Deposit
        [Test]
        public void MakeDeposit()
        {
            // user details 
            string email = "femi@gmail.com";
            string name = "femi";
            string password = "12345";
            int acctype = 0;
            decimal amtDeposit = 5000;
            string note = "just paid into account";
            // register user 
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            // user account balance 
            var balance = account.Balance;
            // deposit money to user account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, note,account.AccountType);

            // test account for increment by amount deposited 
            Assert.That(account.Balance, Is.EqualTo(balance + amtDeposit));




        }

        // test case for account withdrawal
        [Test]
        public void MakeWithdrawal()
        {
            // user details 
            string email = "bola@gmail.com";
            string name = "bola";
            string password = "12345";
            int acctype = 0;
            // amount to deposit
            decimal amtDeposit = 5000;
            string note = "withdraw money";
            // register user 
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            // deposit money into account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, note, account.AccountType);
            // user account balance
            var balance = account.Balance;
            // amount to withdraw from account 
            decimal amtWithdraw = 1000;
            // withdraw from user account
            account.MakeWithdrawal(account.AccountNumber,amtWithdraw, note, account.AccountType);
            // test user account for decrement by the amount withdraw
            Assert.That(account.Balance, Is.EqualTo(balance - amtWithdraw));

        }

        [Test]
        public void MakeTransfer() {

            // 1st user details 
            string email = "roland@gmail.com";
            string name = "roland";
            string password = "12345";
            int acctype = 0;
            // amount to deposit to 1st user account 
            decimal amt = 5000;
            string note = "withdraw money";
            // regsiter 1st user  
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            // Deposit Money into 1st user acount
            account.MakeDeposit(account.AccountNumber, amt, note, account.AccountType);
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
            decimal amtTransfer= 1000;
            // Transfer money from 1st to 2nd account 
            account.MakeTransfer(account.AccountNumber,amtTransfer, note, account.AccountType, account2);
            // test for transfer 
            Assert.That(account.Balance, Is.EqualTo(balance - amtTransfer));


        }

        [Test]
        public void Transactions()
        {

            // user details 
            string email = "bola@gmail.com";
            string name = "bola";
            string password = "12345";
            int acctype = 0;
            // amount to deposit
            decimal amtDeposit = 5000;
            string note = "withdraw money";
            // number of trasactions 
            int count = BankdatasClass.Transactions.Count;
            // register user 
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            // deposit money into account 
            account.MakeDeposit(account.AccountNumber, amtDeposit, note, account.AccountType);
            // new count 
            int newCount = BankdatasClass.Transactions.Count;
            int expexcted = count + 1;

            Assert.That(newCount, Is.EqualTo(expexcted));

           



        }

    }
}