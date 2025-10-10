using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes
{
    public class RepoAlwaysMonsters
    {
        //public double Healt { get; set; }
        //public double Damage { get; set; }
        //public double Armor { get; set; }
        //public double EXP { get; set; }
        //public double Levels { get; set; }
        //public string Power { get; set; }
        //public string[] Vulnerability { get; set; }
        //public string Imges { get; set; }
        //"Cutting", "Stabbing", "Crushing"
        public static List<AlwaysMonsters> AllMonster()
        {
            string[] UnnamedVulnerability;
            Random random = new Random();
            int x = random.Next(0, 4);
            if(x == 0)
            {
                UnnamedVulnerability = new string[] { "Cutting" };
            }
            else if(x == 1)
            {
                UnnamedVulnerability = new string[] { "Stabbing" };
            }
            else if (x == 2)
            {
                UnnamedVulnerability = new string[] { "Crushing" };
            }
            else
            {
                 UnnamedVulnerability = new string[0];
            }
            List<AlwaysMonsters> allMonster = new List<AlwaysMonsters>
            {
                new AlwaysMonsters(100,40,5,15,1,"Easy", new string [] { "Crushing" },"Скелет","pack://application:,,,/Batlle_Сабитов;component/Images/Скелет.png"),
                new AlwaysMonsters(200,25,30,20,1,"Easy", new string [] { "Cutting" },"Зараженный","pack://application:,,,/Batlle_Сабитов;component/Images/Зараженный.png"),
                new AlwaysMonsters(random.Next(50,200),random.Next(50,200),random.Next(0,90),random.Next(15,200),1,"Medium", UnnamedVulnerability,"Неизвестный","pack://application:,,,/Batlle_Сабитов;component/Images/Неизвестный.png"),
                new AlwaysMonsters(350,55,20,300,1,"Hard", new string [] { "Cutting", "Stabbing" },"Извергут","pack://application:,,,/Batlle_Сабитов;component/Images/Олень.png"),
                new AlwaysMonsters(1000,15,0,400,1,"Hard", new string [] { "Stabbing" },"Болотный","pack://application:,,,/Batlle_Сабитов;component/Images/Болотный.png"),
                new AlwaysMonsters(300,45,10,500,1,"Medium", new string [] { "Cutting", "Stabbing" },"Шепчущий Капкан","pack://application:,,,/Batlle_Сабитов;component/Images/Шепчущие-Капканы.png"),
                new AlwaysMonsters(1500,50,60,1200,1,"VeryHard", new string [] { "Cutting" },"Пожиратель  Дюн","pack://application:,,,/Batlle_Сабитов;component/Images/Пожиратель.png"),
                new AlwaysMonsters(700,100,45,1100,1,"VeryHard", new string [] { "Stabbing" },"Пустынный Левиафан","pack://application:,,,/Batlle_Сабитов;component/Images/Пустынный.png"),
                new AlwaysMonsters(8000,150,45,0,0,"Impossible", new string [] { "Cutting", "Stabbing" },"Колмисильма","pack://application:,,,/Batlle_Сабитов;component/Images/Колмисильма.png"),
            };
            return allMonster;
        }
    }
}
