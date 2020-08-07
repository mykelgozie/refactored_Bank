using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.BankLibs
{
    public class TransactionClass
    {

        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string type { get; set; }
        public DateTime DateOfTransaction { get; set; }


        public TransactionClass(int accNum, decimal amt, string note, string type, DateTime date)
        {
            Random value = new Random();
            this.Id = value.Next(1, 1000);
            this.AccountNumber = accNum;
            this.Amount = amt;
            this.Note = note;
            this.type = type;
            this.DateOfTransaction = date;
        }

    }
}
