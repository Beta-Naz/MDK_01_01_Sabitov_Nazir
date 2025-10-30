using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Сабитов.Classes
{
    public class RepoRandomPassport
    {
        static readonly Random rd = new Random();
        static readonly List<string> Names = new List<string>() {"Назир", "Иван", "Назар", 
            "Владислав", "Вадим", "Данил", "Петр","Дамир","Дазздаперма","Руслан","Азамат",};
        static readonly List<string> FirstName = new List<string>() {"Сабитов", "Ширинкин", "Богданов",
            "Александров", "Петров", "Владимиров", "Гигов","Харов","Джугашвили","Волков","Ощепков",};
        static readonly List<string> Forename = new List<string>() {"Назипович", "Сергеевич", "Олегович",
            "Виссарионович", "Петрович", "Адамович", "Зиновьевич","Рюрикович","Юлианович","Жамсараевич","Бенедиктович",};
        static public Passport RandomPassport()
        {
            int DayOfBirht = rd.Next(10, 16);
            int MothOfBirht = rd.Next(1, 10);
            int YearOfBirht = rd.Next(0, 10);
            Passport passport = new Passport()
            {
                Name = Names[rd.Next(0, Names.Count)],
                FirstName = FirstName[rd.Next(0, Names.Count)],
                Forename = Forename[rd.Next(0, Names.Count)],
                Issued = "ГУ МВД",
                DateOfIssued = $"{DayOfBirht + 4}.0{MothOfBirht}.20{YearOfBirht + 14}",
                DepartmentCode = $"{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}-{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}",
                SeriesAndNumber = $"56{YearOfBirht + 14}{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}{rd.Next(0, 10)}",
                DateOfBirth = $"{DayOfBirht}.0{MothOfBirht}.200{YearOfBirht}",
                PlaceOfBirth = $"Пермь"
            };
            return passport;
        }
    }
}
