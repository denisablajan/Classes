using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class User : Person
    {
        string Email;
        string Password;

        public User(string Email, string Password, string FirstName, string LastName, DateTime BirthDate) 
            : base(FirstName, LastName, BirthDate)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public void CreateAccount() {}
    }
}
