using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Batlle_Сабитов.Classes
{
    public class NeedMetod
    {
        //"Cutting", "Stabbing", "Crushing"
        public static readonly Dictionary<string, Brush> PowerAndVulnerabilityMonster = new Dictionary<string, Brush>
        {
            ["Easy"] = Brushes.Green,
            ["Medium"] = Brushes.GreenYellow,
            ["Hard"] = Brushes.Orange,
            ["VeryHard"] = Brushes.DarkRed,
            ["VeryHard"] = Brushes.DarkViolet,
            ["Cutting"] = Brushes.Silver,
            ["Stabbing"] = Brushes.Red,
            ["Crushing"] = Brushes.Brown,
            ["CuttingAndStabbing"] = Brushes.Violet,
            [""] = Brushes.BlueViolet,
        };
        public static readonly Dictionary<string, Brush> Color = new Dictionary<string, Brush>
        {
            ["#FF7FFFD4"] = Brushes.Aquamarine,
            ["#FFFFFF00"] = Brushes.Yellow,
            ["#FFFF0000"] = Brushes.DarkRed,
        };
        public static string SelectVulnerability(string[] Vulne)
        {
            if(Vulne.Length == 1)
            {
                return Vulne[0];
            }
            if(Vulne.Contains("Cutting") && Vulne.Contains("Stabbing") && !Vulne.Contains("Crushing"))
            {
                return "CuttingAndStabbing";
            }
            return "";
        }
        public static double MinusHealt(double width, double healt, double ArmorMonstr)
        {
            return (width / healt) * Player.Damage * CalculateArmor(ArmorMonstr);
        }
        public static double CalculateArmor(double Armor)
        {
            return 1 - Armor * 0.01;
        }
        public static List<string> CalculateAllowedLocations(string nameFirstLocation, string nameSecondLocation)
        {
             return new List<string>() { nameFirstLocation, nameSecondLocation };
        }
        public static void DeadMonsters(double monsterEXP)
        {
            Player.EXP += monsterEXP;
        }
    }
}
