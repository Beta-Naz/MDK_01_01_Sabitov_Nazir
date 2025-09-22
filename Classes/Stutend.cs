using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors_Сабитов.Classes
{
    public class Student
    {
        public string Firstname = "", Lastname = "", Surname = "";
        public bool Scholarship = false;
        public int Course = 4;

        public Student(string firstname, string lastname, string surname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Surname = surname;
        }
        public Student(string firstname, string lastname, string surname, bool scholarship)
            : this(firstname, lastname, surname) 
            {
                Scholarship = scholarship;
        }

        public Student(string firstname, string lastname, string surname, bool scholarship, int course)
            : this(firstname, lastname, surname, scholarship)
        {
            Course = course;
        }
        public string GetFIO()
        {
            return $"{Lastname} {Firstname} {Surname}";
        }
    }
}
