using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class User : Person
    {
        Account[] accounts;
        public string Email;
        public string Password;

        public User()
        {
            this.Email = "";
            this.Password = "";
            accounts = new Account[0];
        }

        public User(string Email, string Password, string FirstName, string LastName, DateTime BirthDate, Gender gender) 
            : base(FirstName, LastName, BirthDate, gender)
        {
            this.Email = Email;
            this.Password = Password;
            accounts = new Account[0];
        }

        public void CreateAccount(string UserEmail, string UserFirstName, string UserLastName, DateTime UserBirthDate)
        {
            bool ok = true;
            foreach (Account acc in accounts)
            {
                if (!(UserEmail.Equals(acc.Email)))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    break;
                }
            }
            if (ok == true)
            {
                Account account = new Account(UserEmail, UserFirstName, UserLastName, UserBirthDate);
                AddAccount(account);                
            }
            else
            {
                Console.WriteLine();
            }
        }

        public void AddAccount(Account accToAdd)
        {

            int newLenght = accounts.Length + 1;
            Account[] aux = new Account[newLenght];
            int item = 0;

            foreach (Account account in accounts)
            {
                aux[item++] = account;
            }
            aux[item] = accToAdd;

            this.accounts = new Account[newLenght];
            Array.Copy(aux, 0, accounts, 0, newLenght);
        }

        public Account LoginAccount(string email)
        {
            foreach(Account acc in accounts)
            {
                if (acc.Email.Equals(email))
                {
                    return acc;
                }
            }
            return null;
        }
    }
}
