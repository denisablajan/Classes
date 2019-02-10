using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public abstract class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;
        public Gender gender;

        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public override string ToString()
        {
            return FullName;
        }

        public Person(string FirstName, string LastName, DateTime BirthDate, Gender gender)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.gender = gender;
        }

        public Person(string FirstName, string LastName, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
        }

        public Person()
        {
            this.FirstName = "";
            this.LastName = "";
            this.BirthDate = DateTime.Now;
            this.gender = Gender.NotSpecified;
        }
    }
}
