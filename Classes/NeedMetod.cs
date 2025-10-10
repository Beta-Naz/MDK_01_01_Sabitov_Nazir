using Batlle_Сабитов.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Batlle_Сабитов.Classes
{
    public class NeedMetod
    {
        public static Random random = new Random();

        public static int death;

        //"Cutting", "Stabbing", "Crushing"
        public static readonly Dictionary<string, Brush> PowerAndVulnerabilityMonster = new Dictionary<string, Brush>
        {
            ["Easy"] = Brushes.Yellow,
            ["Medium"] = Brushes.Orange,
            ["Hard"] = Brushes.Red,
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
        public static double MinusHealtForPlayer(double damage)
        {
            return damage * CalculateArmor(Player.Armor);
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
            Batlle.СhangeTurn();
            death--;
            if(death <= 0)
            {
                AddMonster.AddWorldMap();
            }
        }
        public static void RandomCountMosters()
        {
            int countMonsters = random.Next(1, 101);
            if(countMonsters <= AlwaysMonsters.ChanceCountSpawnMonster[0])
            {
                Batlle.init.SpawnMonsters.Children.Clear();
                Turn.ResetTurns(1);
                Batlle.init.SpawnMonsters.Children.Add(new Elements.OneMonster(AlwaysMonsters.WhatSpawnMonsters));
            }
            else if(countMonsters > AlwaysMonsters.ChanceCountSpawnMonster[0] 
                && AlwaysMonsters.ChanceCountSpawnMonster[0] + AlwaysMonsters.ChanceCountSpawnMonster[1] >= countMonsters)
            {
                Batlle.init.SpawnMonsters.Children.Clear();
                Turn.ResetTurns(2);
                Batlle.init.SpawnMonsters.Children.Add(new Elements.TwoMonster(AlwaysMonsters.WhatSpawnMonsters));
            }
            else if (countMonsters > AlwaysMonsters.ChanceCountSpawnMonster[0] + AlwaysMonsters.ChanceCountSpawnMonster[1] 
                && 100 >= countMonsters)
            {
                Batlle.init.SpawnMonsters.Children.Clear();
                Turn.ResetTurns(4);
                Batlle.init.SpawnMonsters.Children.Add(new Elements.FourMonster(AlwaysMonsters.WhatSpawnMonsters));
            }
        }
        public static void ResetWhatSpawnMosters(string nameLocation)
        {
            List<AlwaysMonsters> alwaysMonsters = new List<AlwaysMonsters>();
            foreach (CreateLocations locations in RepoAllLocations.AllLocations())
            {
                if(locations.NameLocations == nameLocation)
                {
                    int[] countPower = new int[4];
                    foreach (string nameMonster in locations.ActiveMonsters)
                    {
                        foreach(AlwaysMonsters monster in RepoAlwaysMonsters.AllMonster())
                        {
                            if (nameMonster == monster.Name)
                            {
                                alwaysMonsters.Add(monster);
                                if (monster.Power == "Easy")
                                {
                                    countPower[0]++;
                                }
                                else if(monster.Power == "Medium")
                                {
                                    countPower[1]++;
                                }
                                else if(monster.Power == "Hard")
                                {
                                    countPower[2]++;
                                }
                                else if(monster.Power == "VeryHard")
                                {
                                    countPower[3]++;
                                }
                            }
                        }
                    }
                    double[] difference = new double[4];
                    for (int i = 0; i < difference.Length; i++)
                    {
                        difference[i] = countPower[i] * AlwaysMonsters.ChanceSpawnMonster[i];
                    }
                    double SumChance = difference.Sum();
                    double[] allChance = new double[4];
                    for (int i = 0; i < difference.Length; i++)
                    {
                        allChance[i] = (difference[i] / SumChance) * 1000;
                    }
                    CreateNewSpawnMosters(alwaysMonsters, allChance, countPower);
                }
            }
        }
        public static void CreateNewSpawnMosters(List<AlwaysMonsters>allMonsters, double[] chance, int[] countPower)
        {
            AlwaysMonsters.WhatSpawnMonsters.Clear();
            for (int i = 0; i < 4; i++)
            {
                int[] Valid = new int[] {1,1,1,1};
                int[] countRd = new int[4];
                int rd = random.Next(1, 1001);
                for(int j = 0; j < 4; j++)
                {
                    countRd[j] = random.Next(1, countPower[j] + 1);
                }
                foreach (var monster in allMonsters)
                {
                    if (monster.Power == "Easy" && chance[0] >= rd && chance[0] != 0)
                    {
                        if (Valid[0] == countRd[0])
                        {
                            AlwaysMonsters.WhatSpawnMonsters.Add(monster);
                            break;
                        }
                        else
                        {
                            Valid[0]++;
                        }
                    }
                    else if (monster.Power == "Medium" && chance[0] < rd
                        && chance[0] + chance[1] >= rd && chance[1] != 0)
                    {
                        if (Valid[1] == countRd[1])
                        {
                            AlwaysMonsters.WhatSpawnMonsters.Add(monster);
                            break;
                        }
                        else
                        {
                            Valid[1]++;
                        }
                    }
                    else if (monster.Power == "Hard" && chance[0] + chance[1] < rd
                        && chance[0] + chance[1] + chance[2] >= rd && chance[2] != 0)
                    {
                        if (Valid[2] == countRd[2])
                        {
                            AlwaysMonsters.WhatSpawnMonsters.Add(monster);
                            break;
                        }
                        else
                        {
                            Valid[2]++;
                        }
                    }
                    else if (monster.Power == "VeryHard" && chance[0] + chance[1] + chance[2] < rd && 1000 >= rd && chance[3] != 0)
                    {
                        if (Valid[3] == countRd[3])
                        {
                            AlwaysMonsters.WhatSpawnMonsters.Add(monster);
                            break;
                        }
                        else
                        {
                            Valid[3]++;
                        }
                    }
                }
            }
        }
    }
}
