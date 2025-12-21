using Batlle_Сабитов.Elements;
using System.Collections.Generic;

namespace Batlle_Сабитов.Classes.Metod
{
    public class SwitchingLocations
    {
        public static void DeadMonsters(double monsterEXP, int monsterMoney)
        {
            Player.EXP += monsterEXP;
            Player.Money += monsterMoney;
            Batlle.СhangeTurn();
            if (Metod.Variables.death <= 0)
            {
                AddMonster.AddWorldMap();
            }
        }
        public static List<string> CalculateAllowedLocations(string nameFirstLocation, string nameSecondLocation)
        {
            return new List<string>() { nameFirstLocation, nameSecondLocation };
        }
    }
}
