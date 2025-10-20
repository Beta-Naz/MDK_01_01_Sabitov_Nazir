using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload_Сабитов.Classes
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public string Forename;
        public Student(string firstName, string lastName) 
        { 
            FirstName = firstName;
            LastName = lastName;
        }
        public Student(string firstName, string lastName, string forename) 
            : this(firstName, lastName)
        {
            Forename = forename;
        }
        public string GetFIO()
        {
            return $"{FirstName} {LastName} {Forename},";
        }
        public string GetFIO(string a)
        {
            return $"{FirstName} {LastName} {Forename}{a}";
        }
    }
}
