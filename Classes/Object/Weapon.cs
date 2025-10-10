using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    public class Weapon : Items
    {
        public static double MultiplierDamage { get; set; }
        public static double CriticalСhance { get; set; }
        public static double DebuffDexterity {  get; set; }
        public static double CriticalDamage { get; set; }
        public static List<string> TypeDamage { get; set; }

        public Weapon(int price, string images, string name, bool canUse, double multiplierDamage,
            double criticalСhance, double criticalDamage, double debuffDexterity, 
            List<string> typeDamage) : base(price, images, name, canUse)
        {
            MultiplierDamage = multiplierDamage;
            CriticalСhance = criticalDamage;
            DebuffDexterity = debuffDexterity;
            CriticalDamage = criticalDamage;
            TypeDamage = typeDamage;
        }
    }
}
