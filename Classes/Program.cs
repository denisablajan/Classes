using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoardLibrary;

namespace Classes
{
    class Program
    {
        static User[] users = new User[0];
        static void Main(string[] args)
        {
            Board messagesBoard = new Board();
            
            while (true)
            {
                DisplayMenu();
                Console.Write("\n Your option is: ");
                int option = int.Parse(Console.ReadLine());
                
                switch(option)
                {
                    case 1:
                        User user = ReadUserData();
                        AddUser(user);
                        user.CreateAccount(user.Email, user.FirstName, user.LastName, user.BirthDate);
                        break;
                    case 2:
                        Console.WriteLine();
                        Post postToAdd = new Post(Login());
                        if (postToAdd.Author != null)
                        {                            
                            messagesBoard.CreatePost(postToAdd);
                        }
                        else
                        {
                            Console.WriteLine("\n You don't have an account!");
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        Post postToRemove = new Post(Login());
                        if (postToRemove.Author != null)
                        {
                            messagesBoard.RemovePost(postToRemove);
                        }
                        else
                        {
                            Console.WriteLine("\n You don't have an account!");
                        }                        
                        break;
                    case 4:
                        Console.WriteLine();
                        messagesBoard.SortPostsChronologically();
                        messagesBoard.DisplayPosts();
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n\n\tChoose what you want to do:\n");
            Console.WriteLine("  1.Create an account");
            Console.WriteLine("  2.Create a post");
            Console.WriteLine("  3.Remove a post");
            Console.WriteLine("  4.Display all posts");
            Console.WriteLine("  5.Exit");
        }

        static Account Login()
        {
            Console.Write("  Email: ");
            string email = Console.ReadLine().ToString();
            User user = new User();
            foreach (User u in users)
            {
                if(u == null)
                {
                    return null;
                }
                else if (u.Email.Equals(email))
                {
                    user = u;
                }
            }
            Account accountUser = user.LoginAccount(email);
            return accountUser;
        }

        static User ReadUserData()
        {
            Console.WriteLine("\n Introduce your personal data:");

            Console.Write("  First name: ");
            string firstName = Console.ReadLine().ToString();

            Console.Write("  Last name: ");
            string lastName = Console.ReadLine().ToString();

            Console.Write("  Birthdate: \n  Day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("  Month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("  Year: ");
            int year = int.Parse(Console.ReadLine());

            if (!IsValid(day, month, year))
            {
                do
                {
                    Console.WriteLine("\tInvalid date. Try again.");
                    Console.Write("  Day: ");
                    day = int.Parse(Console.ReadLine());
                    Console.Write("  Month: ");
                    month = int.Parse(Console.ReadLine());
                    Console.Write("  Year: ");
                    year = int.Parse(Console.ReadLine());
                } while (!IsValid(day, month, year));
            }

            DateTime birthdate = new DateTime(year, month, day);

            Console.Write("  Email: ");
            string email = Console.ReadLine().ToString();

            Console.Write("  Password: ");
            string password = Console.ReadLine().ToString();

            Console.Write("  Enter the first letter of your gender (F/M):  ");
            Gender gender = GenderCheck();

            User user = new User(email, password, firstName, lastName, birthdate, gender);

            return user;
        }

        static void AddUser(User user)
        {
            int newLenght = users.Length + 1;
            User[] aux = new User[newLenght];
            int item = 0;

            foreach (User u in users)
            {
                if (!(user.Email.Equals(u.Email)) && !(user.Password.Equals(u.Password)))
                {

                    aux[item++] = u;
                }
            }

            aux[item] = user;
            Console.WriteLine("\n  Account created.");

            users = new User[newLenght];
            Array.Copy(aux, 0, users, 0, newLenght);
        }

        static bool ValidGender(char genderInput)
        {
            if ((genderInput != 'F') && (genderInput != 'M'))
                return false;
            return true;
        }

        static Gender GenderCheck()
        {

            char genderInput = char.Parse(Console.ReadLine());
            Gender gender = Gender.NotSpecified;

            if (!ValidGender(genderInput))
            {
                do
                {
                    Console.WriteLine("\n  Try again:");
                    genderInput = char.Parse(Console.ReadLine());
                } while (!ValidGender(genderInput));
            }

            switch (genderInput)
            {
                case 'F':
                    gender = Gender.Female;
                    break;
                case 'M':
                    gender = Gender.Male;
                    break;
            }
            return gender;
        }

        static bool IsLeap(int year)
        {
            return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));
        }

        static bool IsValid(int day, int month, int year)
        {
            //check if date is not out of range
            if (year > DateTime.Now.Year || year <= 0)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (day < 1 || day > 31)
                return false;
            //check for April, June, September, November
            if (month == 4 || month == 6 || month == 9 || month == 10)
                return day <= 30;
            //check Leap Day / Leap Year
            if (month == 2)
            {
                if (IsLeap(year))
                    return day <= 29;
                else
                    return day <= 28;
            }            
            return true;
        }
    }
}
