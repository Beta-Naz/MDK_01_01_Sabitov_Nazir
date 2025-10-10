using Batlle_Сабитов.Classes.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes
{
    public class RepoAllLocations
    {
        public static List<CreateLocations> AllLocations()
        {
            List<CreateLocations> allLocations = new List<CreateLocations>()
            {
                new CreateLocations(new List<string>{"Скелет", "Зараженный"},"Лощина Последнего Вздоха","Easy","pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_локация_1.png"),
                new CreateLocations(new List<string>{"Скелет", "Зараженный","Неизвестный"},"Безгласная Пуща","Medium", "pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_локация_2.png"),
                new CreateLocations(new List<string>{"Скелет", "Зараженный", "Неизвестный", "Болотный"},"Гниющие Сады Ксанату","Hard", "pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_локация_3.png"),
                new CreateLocations(new List<string>{"Скелет", "Зараженный", "Неизвестный", "Извергут"},"Земли, Непомнящие Солнца","VeryHard", "pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_локация_4.png"),
                new CreateLocations(new List<string>{ "Шепчущий Капкан", "Пожиратель  Дюн","Пустынный Левиафан" },"Последний Приют Падших Титанов","VeryHard", "pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_локация_5.png"),
                new CreateLocations(new List<string>{ "Колмисильма" },"Склеп Нерожденного Бога","Impossible", "pack://application:,,,/Batlle_Сабитов;component/Images/Background/Фон_финал.png"),
            };
            return allLocations;
        }
        public static List<CreateEndLocations> AllEndLocations()
        {
            List<CreateEndLocations> allLocations = new List<CreateEndLocations>()
            {
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_Хаос.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_побежденный_бог.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_обрущение_пещеры.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_локация_5_(мирное_время).png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_локация_4_(мирное_время).jpg"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_локация_3_(мирное_время).png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_локация_2_(мирное_время).png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_локация_1_(мирное_время).png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_Победа.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_праздник.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_тронный_зал.png"),
                new CreateEndLocations("pack://application:,,,/Batlle_Сабитов;component/Images/The end/Фон_конец.png"),
            };
            return allLocations;
        }
    }
}
