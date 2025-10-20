using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Overload_Сабитов.Classes
{
    public class RepoStudents
    {
        public static List<Student> AllStudents()
        {
            List<Student> allStudents = new List<Student>()
            {
                new Student("Сабитов", "Назир", "Назипович"),
                new Student("Ширинкин", "Иван", "Сергеевич"),
                new Student("Мацкевич", "Владислав", "Денисович"),
                new Student("Максимович", "Мэксим", "Братчикович")
            };
            return allStudents;
        }
    }
}
