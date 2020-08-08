using bankapp_refactored_week4.BankLibs;
using NUnit.Framework;



namespace refactored_Test
{
    [TestFixture]
    public class Tests
    {
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

        [Test]
        public void MakeDeposit()
        {
            string email = "femi@gmail.com";
            string name = "femi";
            string password = "12345";
            int acctype = 0;
            decimal amt = 5000;
            string note = "just paid into account";
            AccountClass account = AuthClass.Register(name, email, password, acctype);
            var balance = account.Balance;


            account.MakeDeposit(account.AccountNumber, amt, note,account.AccountType);
            Assert.That(account.Balance, Is.EqualTo(balance + 5000));




        } 


     
    
    }
}