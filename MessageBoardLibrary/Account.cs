using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Account : Person
    {
        public string Email;
        public string LastName;
        public string FirstName;
        DateTime Birthdate;

        public Account(string Email, string FirstName, string LastName, DateTime Birthdate) 
            : base(FirstName, LastName, Birthdate)
        {
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Birthdate = Birthdate;
        }
    }
}
