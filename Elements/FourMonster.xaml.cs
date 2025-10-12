using Batlle_Сабитов.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для FourMonster.xaml
    /// </summary>
    public partial class FourMonster : UserControl
    {
        Classes.AlwaysMonsters firstMonsters;
        Classes.AlwaysMonsters secondMonsters;
        Classes.AlwaysMonsters thirdMonsters;
        Classes.AlwaysMonsters fourthMonsters;
        public FourMonster(List<Classes.AlwaysMonsters> Monsters)
        {
            InitializeComponent();

            Classes.Metod.Variables.death = 4;

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

            thirdMonsters = Monsters[2];
            ThirdImageMonster.Source = new BitmapImage(new Uri(thirdMonsters.Images));
            ThirdMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(thirdMonsters.Vulnerability)];
            ThirdMonsterPower.Content = thirdMonsters.Name;
            ThirdMonsterPower.Foreground = Classes.Metod.Variables.PowerAndVulnerabilityMonster[thirdMonsters.Power];
            TextHealtThird.Content = thirdMonsters.Healt;

            fourthMonsters = Monsters[3];
            FourthImageMonster.Source = new BitmapImage(new Uri(fourthMonsters.Images));
            FourthMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(fourthMonsters.Vulnerability)];
            FourthMonsterPower.Content = fourthMonsters.Name;
            FourthMonsterPower.Foreground = Classes.Metod.Variables.PowerAndVulnerabilityMonster[fourthMonsters.Power];
            TextHealtFourth.Content = fourthMonsters.Healt;
        }

        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.MaxHealt, firstMonsters.Armor, firstMonsters.Vulnerability);
                if (FirstHealtBarMonster.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    Turn.RemoveTurn("First");
                    FirstHealtBarMonster.Width = 0;
                    TextHealtFirst.Content = 0;
                    FirstMonster.Children.Clear();
                    Classes.Metod.SwitchingLocations.DeadMonsters(firstMonsters.EXP, firstMonsters.Money);
                }
                else
                {
                    firstMonsters.Healt -= damageForHealt;
                    FirstHealtBarMonster.Width -= damageForBar;
                    TextHealtFirst.Content = Math.Round(firstMonsters.Healt,0);
                    Batlle.СhangeTurn();
                }
            }
        }

        private void SecondMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(SecondHealtMaxBarMonster.Width, secondMonsters.MaxHealt, secondMonsters.Armor, secondMonsters.Vulnerability);
                if (SecondHealtBarMonster.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    Turn.RemoveTurn("Second");
                    SecondHealtBarMonster.Width = 0;
                    TextHealtSecond.Content = 0;
                    SecondMonster.Children.Clear();
                    Classes.Metod.SwitchingLocations.DeadMonsters(secondMonsters.EXP, secondMonsters.Money);
                }
                else
                {
                    secondMonsters.Healt -= damageForHealt;
                    SecondHealtBarMonster.Width -= damageForBar;
                    TextHealtSecond.Content = Math.Round(secondMonsters.Healt,0);
                    Batlle.СhangeTurn();
                }
            }
        }

        private void ThirdMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(ThirdHealtMaxBarMonster.Width, thirdMonsters.MaxHealt, thirdMonsters.Armor, thirdMonsters.Vulnerability);
                if (ThirdHealtBarMonster.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    Turn.RemoveTurn("Third");
                    ThirdHealtBarMonster.Width = 0;
                    TextHealtThird.Content = 0;
                    ThirdMonster.Children.Clear();
                    Classes.Metod.SwitchingLocations.DeadMonsters(thirdMonsters.EXP, thirdMonsters.Money);
                }
                else
                {
                    thirdMonsters.Healt -= damageForHealt;
                    ThirdHealtBarMonster.Width -= damageForBar;
                    TextHealtThird.Content = Math.Round(thirdMonsters.Healt, 0);
                    Batlle.СhangeTurn();
                }
            }
        }

        private void FourthMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(FourthHealtMaxBarMonster.Width, fourthMonsters.MaxHealt, fourthMonsters.Armor, fourthMonsters.Vulnerability);
                if (FourthHealtBarMonster.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    Turn.RemoveTurn("Fourth");
                    FourthHealtBarMonster.Width = 0;
                    TextHealtFourth.Content = 0;
                    FourthMonster.Children.Clear();
                    Classes.Metod.SwitchingLocations.DeadMonsters(fourthMonsters.EXP, fourthMonsters.Money);
                }
                else
                {
                    fourthMonsters.Healt -= damageForHealt;
                    FourthHealtBarMonster.Width -= damageForBar;
                    TextHealtFourth.Content = Math.Round(fourthMonsters.Healt, 0);
                    Batlle.СhangeTurn();
                }
            }
        }
    }
}
