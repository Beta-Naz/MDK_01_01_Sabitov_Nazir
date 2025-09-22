using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Constructors_Сабитов.Classes
{
    public class RepoStudents
    {
        public static List<Student> AllStudents()
        {
            List<Student> allStudent = new List<Student>();
            allStudent.Add(new Student("Болотов", "Евгений", "Олегович"));
            allStudent.Add(new Student("Григорьев", "Роман", "Владимирович"));
            allStudent.Add(new Student("Гудков", "Георгий", "Константинович", false, 3));
            allStudent.Add(new Student("Мылова", "Алёна", "Александровна", true));
            allStudent.Add(new Student("Чутин", "Павел", "Алексеевич", false, 3));
            allStudent.Add(new Student("Ишимов", "Виктор", "Алексеевич"));
            allStudent.Add(new Student("Калижный", "Артём", "Евгеньевич"));
            allStudent.Add(new Student("Кусакина", "Полина", "Олеговна", true));
            allStudent.Add(new Student("Ленченков", "Александр", "Дмитриевич"));
            allStudent.Add(new Student("Лесникова", "Мария", "Михайловна", true));
            allStudent.Add(new Student("Лихачева", "Татьяна", "Яковлевна"));
            allStudent.Add(new Student("Мокрушина", "Надежда", "Владимировна", true));
            allStudent.Add(new Student("Нугагаров", "Даниил", "Ринатович"));
            allStudent.Add(new Student("Нарижный", "Данил", "Владислович"));
            allStudent.Add(new Student("Никонов", "Арсений", "Дмитриевич", false, 3));
            allStudent.Add(new Student("Оборин", "Даниил", "Артемович"));
            allStudent.Add(new Student("Посадских", "Дарья", "Андреевна"));
            allStudent.Add(new Student("Сторожев", "Денис", "Романович", true));
            allStudent.Add(new Student("Суслов", "Егор", "Владимирович"));
            allStudent.Add(new Student("Токмаков", "Даниил", "Сергеевич", true));
            allStudent.Add(new Student("Гронин", "Александр", "Владиславович"));
            allStudent.Add(new Student("Халилов", "Дамир", "Ринатович"));
            allStudent.Add(new Student("Шестаков", "Дмитрий", "Андреевич"));
            return allStudent;
        }
    }
}
