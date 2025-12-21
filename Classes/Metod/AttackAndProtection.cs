using Batlle_Сабитов.Elements;
using System;
using System.Linq;

namespace Batlle_Сабитов.Classes.Metod
{
    public class AttackAndProtection
    {
        public static Random random = new Random();
        public static double MinusHealt(double armorMonstr, string[] typeDamage)
        {
            double Vulnerability = 0.75; //монстр имеет имунитет к этому виду урона
            if (Player.TypeWeapon != null)
            {
                for (int i = 0; i < Player.TypeWeapon.TypeDamage.Count; i++)
                {
                    if (typeDamage.Contains(Player.TypeWeapon.TypeDamage[i]))
                    {
                        Vulnerability = 2; //бонус к атаке
                        break;
                    }
                }
            }
            else if (typeDamage.Contains("Crushing")) //Кулаки ТОЖЕ МОГУТ КРУШИТЬ!
            {
                Vulnerability = 1;
            }
            double Bonus = Player.Damage * BonusForAttack() * Vulnerability * CalculateArmor(armorMonstr);
            return (Bonus);
        }
        public static double MinusHealtForPlayer(double damage, string WhoMonsters)
        {
            double armor = CalculateArmor(Player.Armor);
            Random rd = new Random();
            if(armor != 0)
            {
                var spawn = new[]
                {
                Batlle.init.DamageFromMonstr_1,
                Batlle.init.DamageFromMonstr_2,
                Batlle.init.DamageFromMonstr_3,
                };
                int x = rd.Next(1, 3);
                spawn[x].Children.Add(new Elements.Anim.AnimTextDamageMonsterxaml(damage * armor, WhoMonsters, x));
            }
            return damage * armor;
        }
        public static double CalculateChanceCrit()
        {
            int chanceCrit = random.Next(1, 101);
            if (Player.TypeWeapon != null)
            {
                if (Player.TypeWeapon.CriticalСhance * 100 > chanceCrit)
                {
                    return Player.TypeWeapon.CriticalDamage;
                }
            }
            return 0;
        }
        public static double BonusForAttack()
        {
            if (Player.TypeWeapon != null)
            {
                return CalculateChanceCrit() + Player.TypeWeapon.MultiplierDamage;
            }
            return 1;
        }
        public static double CalculateArmor(double Armor)
        {
            if (Avoidance())
            {
                return 0;
            }
            else
            {
                return 1 - Armor * 0.01;
            }
        }
        public static bool Avoidance()
        {
            if (Batlle.init.TurnOne.Background != Classes.Turn.ColorsToTurn["Player"])
            {
                int countMonsters = random.Next(1, 101);
                if (Player.Dexterity >= countMonsters)
                {
                    Animation.StartTimers("Avoidance");
                    return true;
                }
            }
            return false;
        }
        public static string SelectVulnerability(string[] Vulne)
        {
            if (Vulne.Length == 1)
            {
                return Vulne[0];
            }
            if (Vulne.Contains("Cutting") && Vulne.Contains("Stabbing") && !Vulne.Contains("Crushing"))
            {
                return "CuttingAndStabbing";
            }
            return "";
        }
    }
}
