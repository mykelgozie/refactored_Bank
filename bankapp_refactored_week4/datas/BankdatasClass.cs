using bankapp_refactored_week4.BankLibs;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.datas
{
    public static class BankdatasClass
    {

      
            public static List<CustomerClass> Customers { get; set; } = new List<CustomerClass>();
            public static List<AccountClass> Accounts { get; set; } = new List<AccountClass>();
            public static List<TransactionClass> Transactions { get; set; } = new List<TransactionClass>();

       
    }
}
