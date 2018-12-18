using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;

        public Person(string FirstName, string LastName, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
        }
    }
}
