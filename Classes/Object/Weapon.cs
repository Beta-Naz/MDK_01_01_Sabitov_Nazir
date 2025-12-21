using System.Collections.Generic;

namespace Batlle_Сабитов.Classes.Object
{
    public class Weapon : Items
    {
        public double MultiplierDamage { get; set; }
        public double CriticalСhance { get; set; }
        public double DebuffDexterity {  get; set; }
        public double CriticalDamage { get; set; }
        public List<string> TypeDamage { get; set; }

        public Weapon(int price, string images, string name, bool canUse, double multiplierDamage,
            double criticalСhance, double criticalDamage, double debuffDexterity, 
            List<string> typeDamage) : base(price, images, name, canUse)
        {
            MultiplierDamage = multiplierDamage;
            CriticalСhance = criticalСhance;
            DebuffDexterity = debuffDexterity;
            CriticalDamage = criticalDamage;
            TypeDamage = typeDamage;
        }
    }
}
