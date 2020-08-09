using bankapp_refactored_week4.datas;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace bankapp_refactored_week4.BankLibs
{
    public static class  AuthClass
    {

        public static AccountClass Register(string name, string email, string password, int acctype)
        {
            AccountClass account = null;
            CustomerClass customer = null;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password)
                )
            {

                return account;


            }

           

            customer = new CustomerClass(name, email, password);
            account = new AccountClass(customer.Id, acctype);

            BankdatasClass.Customers.Add(customer);
            BankdatasClass.Accounts.Add(account);
            return account;


        }

        public static AccountClass Login(string email, string password)
        {

            CustomerClass customer = null;
            AccountClass customerAcct = null;
            foreach (var user in BankdatasClass.Customers)
            {
                if (user.Email == email && user.Password == password)
                {
                    customer = user;
                    
                }
            }

            if (customer == null)
            {
                return null;
            }
            else
            {

                foreach (var account in BankdatasClass.Accounts)
                {

                    if (account.OwnerId == customer.Id)
                    {

                        customerAcct = account;

                    }

                }

                return customerAcct;


            }

        }


        public static AccountClass CheckAccount(int acctNum)
        {

            AccountClass usertodeposit = null;

            foreach (var account in BankdatasClass.Accounts)
            {
                if (account.AccountNumber == acctNum)
                {
                    usertodeposit = account;
                    break;
                }


            }

            return usertodeposit;

            

        }

    }
}
