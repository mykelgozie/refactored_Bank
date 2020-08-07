using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.BankLibs
{
       public  class CustomerClass
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }
        public string  Password { get; private set; }

        public CustomerClass(string name, string email, string password)
        {
            Random value = new Random();
            this.Id = value.Next(1,1000);
            this.Name = name;
            this.Email = email;
            this.DateRegistered = DateTime.Now;
            this.Password = password;

        }




    }
}
