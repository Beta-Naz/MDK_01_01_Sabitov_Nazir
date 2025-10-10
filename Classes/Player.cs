using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes
{
    public class Player
    {
        public static double MaxHealt { get; set; }
        public static double Healt { get; set; }
        public static double Damage { get; set; }
        public static double Armor { get; set; }
        public static double Dexterity { get; set; }
        public static double EXP { get; set; } = 0;
        public static double Levels { get; set; } = 1;
        public static string Name { get; set; }
        public static string TypeArmor { get; set; }
        public static string Images { get; set; }
        public static string ColorName { get; set; }
        public static bool ValidAttack { get; set; }
    }
}
