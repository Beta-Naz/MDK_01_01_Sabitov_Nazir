using Batlle_Сабитов.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для TwoMonster.xaml
    /// </summary>
    public partial class TwoMonster : UserControl
    {
        Classes.AlwaysMonsters firstMonsters;
        Classes.AlwaysMonsters secondMonsters;
        public static TwoMonster init;
        public TwoMonster(List<Classes.AlwaysMonsters> Monsters)
        {
            InitializeComponent();

            Classes.Metod.Variables.death = 2;

            firstMonsters = Monsters[0];
            FirstImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            FirstMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(firstMonsters.Vulnerability)];
            FirstMonsterPower.Content = firstMonsters.Name;
            FirstMonsterPower.Foreground = Classes.Metod.Variables.PowerAndVulnerabilityMonster[firstMonsters.Power];
            TextHealtFirst.Content = firstMonsters.Healt;

            secondMonsters = Monsters[1];
            SecondImageMonster.Source = new BitmapImage(new Uri(secondMonsters.Images));
            SecondMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(secondMonsters.Vulnerability)];
            SecondMonsterPower.Content = secondMonsters.Name;
            SecondMonsterPower.Foreground = Classes.Metod.Variables.PowerAndVulnerabilityMonster[secondMonsters.Power];
            TextHealtSecond.Content = secondMonsters.Healt;
        }

        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = Classes.Metod.AttackAndProtection.MinusHealt(firstMonsters.Armor, firstMonsters.Vulnerability);
                if (firstMonsters.Healt - damage <= 0)
                {
                    Classes.Metod.Variables.death--;
                    FirstHealtBarMonster.Width = 0;
                    firstMonsters.Healt = 0;
                    TextHealtFirst.Content = 0;
                    Classes.Metod.SwitchingLocations.DeadMonsters(firstMonsters.EXP, firstMonsters.Money);
                    Turn.RemoveTurn("First");
                    FirstMonster.Children.Clear();
                }
                else
                {
                    firstMonsters.Healt -= damage;
                    TextHealtFirst.Content = Math.Round(firstMonsters.Healt, 0);
                    FirstHealtBarMonster.Width = (firstMonsters.Healt / firstMonsters.MaxHealt) * FirstHealtMaxBarMonster.Width ;
                    Batlle.СhangeTurn();
                }
            }
        }

        private void SecondMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = Classes.Metod.AttackAndProtection.MinusHealt(secondMonsters.Armor, secondMonsters.Vulnerability);
                if (secondMonsters.Healt - damage <= 0)
                {
                    Classes.Metod.Variables.death--;
                    SecondHealtBarMonster.Width = 0;
                    secondMonsters.Healt = 0;
                    TextHealtSecond.Content = 0;
                    Classes.Metod.SwitchingLocations.DeadMonsters(secondMonsters.EXP, secondMonsters.Money);
                    Turn.RemoveTurn("Second");
                    SecondMonster.Children.Clear();

                }
                else
                {
                    secondMonsters.Healt -= damage;
                    TextHealtSecond.Content = Math.Round(secondMonsters.Healt, 0);
                    SecondHealtBarMonster.Width = (secondMonsters.Healt / secondMonsters.MaxHealt) * SecondHealtMaxBarMonster.Width;
                    Batlle.СhangeTurn();
                }
            }
        }
    }
}
