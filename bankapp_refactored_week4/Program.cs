using bankapp_refactored_week4.BankLibs;
using bankapp_refactored_week4.datas;
using bankapp_refactored_week4.Helpers;
using System;

namespace bankapp_refactored_week4
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountClass account = null;
            string option = "";

            while (option != "1" || option != "2")
            {
                Console.WriteLine("Welcome TO decagon Bank ");
                Console.WriteLine("To login press 1 ");
                Console.WriteLine("To Register press 2 ");

                option = Console.ReadLine();

                if (option == "1")
                {
                    string email = "";
                    string password = "";


                    while (string.IsNullOrWhiteSpace(email) ||
                           string.IsNullOrWhiteSpace(password))
                    {


                        try
                        {
                            // collect inputs
                            Console.WriteLine("Enter your email");
                            email = Console.ReadLine();
                            Console.WriteLine("Enter your password");
                            password = Console.ReadLine();

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nInvalid operation");
                        }

                    }


                        account =    AuthClass.Login(email,password);
                    if (account == null)
                    {
                        Console.WriteLine("Invalid User");
                        Environment.Exit(0);
                    }


                }
                else if (option == "2")
                {
                    string name = "";
                    string email = "";
                    string password = "";
                    int acctype = 0;


                    while (string.IsNullOrWhiteSpace(name) ||
                           string.IsNullOrWhiteSpace(email) ||
                           string.IsNullOrWhiteSpace(password))
                    {

                        try
                        {
                            // collect inputs
                            System.Console.WriteLine("All fields are required");
                            Console.WriteLine("Enter your name");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter your email");
                            email = Console.ReadLine();
                            Console.WriteLine("Enter your password");
                            password = Console.ReadLine();
                            Console.WriteLine("Choose an account type");
                            Console.WriteLine(@"Savings: Press 0     |     Current: Press 1");
                            acctype = Convert.ToInt32(Console.ReadLine());
                           

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nInvalid operation");
                        }


                    }
                    new UtilityClass().ValidateEmailFormat(email);

                     account = AuthClass.Register(name, email,password,acctype);
                    Console.WriteLine("Thanks For Registration  ");
                    if (account == null)
                    {
                        Console.WriteLine("Operation failed. Try again.");
                        Environment.Exit(0);
                    }


                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    Environment.Exit(0);
                }


                if (account != null)
                {
                    Console.WriteLine("Hello " + FindCus(account)+  "!!");
                }

                Console.WriteLine("  Deposit: Press 1  ");
                Console.WriteLine("  Withdrawal: Press 2  ");
                Console.WriteLine(" Transfer: Press 3   ");
                Console.WriteLine(" Account Bal: Press 4   ");
                Console.WriteLine("   Account Transction: 5  ");
                Console.WriteLine("     Logout: Press 6  ");

                string opt2 = "";

                while (opt2 != "6")
                {

                     opt2 = Console.ReadLine();

                    if (opt2 == "1")
                    {

                        try
                        {
                            Console.WriteLine("\nHow much do you wish to deposit?");
                            decimal deposit = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nPlease enter a short description note.");
                            string note = Console.ReadLine();
                            note = !string.IsNullOrWhiteSpace(note) ? note : "No note";

                            account.MakeDeposit(account.AccountNumber, deposit, note, account.AccountType);

                            Console.WriteLine($"\nDeposited successfully. Your balance is {account.Balance}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }

                    }else if (opt2 == "2")
                    {

                        try
                        {
                            Console.WriteLine("How much do you want to withdraw?");
                            decimal withdrawal = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nPlease enter a short description note.");
                            string note = Console.ReadLine();
                            note = !string.IsNullOrWhiteSpace(note) ? note : "No note";

                            account.MakeWithdrawal(account.AccountNumber, withdrawal, note, account.AccountType);

                            Console.WriteLine($"\nWithdrawn successfully. Your balance is {account.Balance}");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }



                    }else if (opt2 == "3")
                    {

                        try
                        {
                            Console.WriteLine("\nHow much do you wish to Transfer?");
                            decimal transferAmt = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nPlease Enter Account Number?");
                            int accountNum = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nPlease enter a short description note.");
                            string note = Console.ReadLine();
                            note = !string.IsNullOrWhiteSpace(note) ? note : "No note";

                            AccountClass tranferAcct = AuthClass.CheckAccount(accountNum);

                            if (tranferAcct == null )
                            {
                                throw new ArgumentOutOfRangeException(nameof(accountNum), "Invalid Account Number");
                            }

                            account.MakeTransfer(accountNum, transferAmt, note, account.AccountType, tranferAcct);
                          

                            Console.WriteLine($"\nTransfer is successfully. Your balance is {account.Balance}");
                            Console.WriteLine("Enter 6 to return to menu ");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                            Console.WriteLine("Enter 6 to return to menu ");

                        }


                    }
                    else if (opt2 == "4")
                    {

                        Console.WriteLine("Total balance in account is  " + account.Balance);

                    }else if (opt2 == "5")
                    {
                        decimal bal = 0;

                        Console.WriteLine("Account Number\tAmount\tBalance\tNote");
                        foreach (var transaction in BankdatasClass.Transactions)
                        {
                            if (transaction.AccountNumber == account.AccountNumber)
                            {
                                bal += transaction.Amount;
                                Console.WriteLine($"{transaction.AccountNumber}\t{transaction.Amount}\t{bal}\t{transaction.Note}");
                            }
                        }


                    }
                }


            }


        }

        public static string FindCus(AccountClass  user)
        {
            CustomerClass person = null;

            foreach (var cus in BankdatasClass.Customers)
            {
                if (cus.Id == user.OwnerId)
                {
                    person = cus;
                    break;

                }
            }

            return person.Name;
        }


    }

  
}
