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
        public static int Money { get; set; }
        public static double Damage { get; set; }
        public static double Armor { get; set; }
        public static double MaxUppDexterity { get; set; } = 0;
        public static double Dexterity { get; set; }
        private static double exp;
        public static double EXP { 
            get 
            { 
                return exp; 
            } 
            set 
            {
                exp = value;
                if (value >= 10 * ((Levels - 1) * 0.2 + 1))
                {
                    exp -= 10 * ((Levels - 1) * 0.2 + 1);
                    Levels++;
                    FreeLevels++;
                    return;
                };
            } 
        }
        public static double Levels { get; set; } = 1;
        public static double FreeLevels { get; set; } = 0;
        public static string Name { get; set; }
        public static string TypeArmor { get; set; }
        public static Object.Weapon TypeWeapon { get; set; }
        public static string Images { get; set; }
        public static string ColorName { get; set; }
        public static bool ValidAttack { get; set; }
    }
}
