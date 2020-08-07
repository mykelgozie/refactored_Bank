using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.Helpers
{
    public class UtilityClass
    {
        public bool ValidateMail(string email)
        {
            return email.Contains("@") ? true : false;

        }


        public string ValidateEmailFormat(string email)
        {
            bool isEmValid = false;
            isEmValid = ValidateMail(email);
            string em = "";

            while (isEmValid == false)
            {
                System.Console.WriteLine("\nInvalid email format");
                Console.WriteLine("Enter email again");
                em = Console.ReadLine();
                isEmValid = ValidateMail(em);
            }

            return em;
        }
    }
}
