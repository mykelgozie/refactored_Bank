using bankapp_refactored_week4.datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.BankLibs
{
    public  class AccountClass : InterfaceAccount
    {


        public int AccountNumber { get; private set; }
        
        public int OwnerId { get; set; }

        public DateTime DateRegistered { get; set; }

        public AccountType AccountType { get; set; }
        public List<TransactionClass> Transactions { get; set; }

        public decimal Balance
        {
            get
            {
                decimal bal = 0;
                foreach (var item in BankdatasClass.Transactions)
                {
                    if (item.AccountNumber == this.AccountNumber)
                        bal += item.Amount;
                }
                return bal;
            }
        }


        public  AccountClass(int ownerId, int accountType)
        {
            Random value = new Random();
            this.AccountNumber = value.Next(100,999);
            this.OwnerId = ownerId;
            this.AccountType = (AccountType)accountType;
            this.DateRegistered = DateTime.Now;
            this.Transactions = new List<TransactionClass>();
            //this.MakeDeposit(this.AccountNumber, initialBalance, "Initial balance", AccountType);
        }

        public void MakeDeposit(int accNum, decimal amt, string note, AccountType type)
        {
            if (amt < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amt), "Deposit amount must be positive");
            }

            // add a new deposit
            TransactionClass deposit = new TransactionClass(accNum, amt, note, type.ToString(), DateTime.Now);
            BankdatasClass.Transactions.Add(deposit);


        }

     

        public void MakeWithdrawal(int accNum, decimal amt, string note, AccountType type)
        {
            if (amt < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amt), "Deposit amount must be positive");
            }

            if (type.ToString() == "Savings" && Balance - amt < 100)
            {
                throw new InvalidOperationException("You don't have sufficient fund for this operation");
            }

            if (type.ToString() == "Current" && Balance - amt < 1000)
            {
                throw new InvalidOperationException("You don't have sufficient fund for this operation");
            }

            // add a new deposit
            TransactionClass withdrawal = new TransactionClass(accNum, -amt, note, type.ToString(), DateTime.Now);
            BankdatasClass.Transactions.Add(withdrawal);
        }

        public void MakeTransfer(int accNum, decimal amt, string note, AccountType type, AccountClass account)
        {
            string noteAdd = "Tranfer From " + accNum + " : " + note;
            MakeWithdrawal(AccountNumber,amt, note, type);
            account.MakeDeposit(account.AccountNumber, amt, noteAdd, type);

        }

      
    }
}
