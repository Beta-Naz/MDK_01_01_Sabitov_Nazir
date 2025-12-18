using System.Collections.Generic;

namespace Constructors_Сабитов.Classes
{
    public class RepoStudents
    {
        public static List<Student> AllStudents()
        {
            List<Student> allStudent = new List<Student>
            {
                new Student("Болотов", "Евгений", "Олегович"),
                new Student("Григорьев", "Роман", "Владимирович"),
                new Student("Гудков", "Георгий", "Константинович", false, 3),
                new Student("Мылова", "Алёна", "Александровна", true),
                new Student("Чутин", "Павел", "Алексеевич", false, 3),
                new Student("Ишимов", "Виктор", "Алексеевич"),
                new Student("Калижный", "Артём", "Евгеньевич"),
                new Student("Кусакина", "Полина", "Олеговна", true),
                new Student("Ленченков", "Александр", "Дмитриевич"),
                new Student("Лесникова", "Мария", "Михайловна", true),
                new Student("Лихачева", "Татьяна", "Яковлевна"),
                new Student("Мокрушина", "Надежда", "Владимировна", true),
                new Student("Нугагаров", "Даниил", "Ринатович"),
                new Student("Нарижный", "Данил", "Владислович"),
                new Student("Никонов", "Арсений", "Дмитриевич", false, 3, @"pack://application:,,,/Constructors_Сабитов;component/Images/Я.png"),
                new Student("Оборин", "Даниил", "Артемович"),
                new Student("Посадских", "Дарья", "Андреевна"),
                new Student("Сторожев", "Денис", "Романович", true),
                new Student("Суслов", "Егор", "Владимирович"),
                new Student("Токмаков", "Даниил", "Сергеевич", true),
                new Student("Гронин", "Александр", "Владиславович"),
                new Student("Халилов", "Дамир", "Ринатович"),
                new Student("Шестаков", "Дмитрий", "Андреевич")
            };
            return allStudent;
        }
    }
}
