using System.Collections.Generic;

namespace Batlle_Сабитов.Classes
{
    public class AlwaysMonsters
    {
        public double Healt { get; set; }
        public double MaxHealt { get; set; }
        public double Damage { get; set; }
        public double Armor { get; set; }
        public double EXP { get; set; }
        public double Levels { get; set; }
        public string Power {  get; set; }
        public string [] Vulnerability { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public int Money { get; set; }

        public AlwaysMonsters(double Healt, double Damage, double Armor, double EXP, double Levels, string Power, string[] Vulnerability, string Name, string Images, int Money)
        {
            this.Healt = Healt;
            MaxHealt = Healt;
            this.Damage = Damage;
            this.Armor = Armor;
            this.EXP = EXP;
            this.Levels = Levels;
            this.Power = Power;
            this.Vulnerability = Vulnerability;
            this.Name = Name;
            this.Images = Images;
            this.Money = Money;
        }
        public static int[] ChanceCountSpawnMonster;
        public static List<AlwaysMonsters> WhatSpawnMonsters = new List<AlwaysMonsters>();
        public static double[] ChanceSpawnMonster = new double[] {2,1.75,1.5,1};
    }
}
