using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.BankLibs
{
    interface InterfaceAccount
    {
        public void MakeDeposit(int accNum, decimal amt, string note, AccountType type);
        public void MakeWithdrawal(int accNum, decimal amt, string note, AccountType type);
        public void MakeTransfer(int accNum, decimal amt, string note, AccountType type, AccountClass account);


    }
}
