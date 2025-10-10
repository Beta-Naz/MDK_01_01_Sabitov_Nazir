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

            NeedMetod.death = 4;

            firstMonsters = Monsters[0];
            FirstImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            FirstMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(firstMonsters.Vulnerability)];
            FirstMonsterPower.Content = firstMonsters.Name;
            FirstMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[firstMonsters.Power];

            secondMonsters = Monsters[1];
            SecondImageMonster.Source = new BitmapImage(new Uri(secondMonsters.Images));
            SecondMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(secondMonsters.Vulnerability)];
            SecondMonsterPower.Content = secondMonsters.Name;
            SecondMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[secondMonsters.Power];

            thirdMonsters = Monsters[2];
            ThirdImageMonster.Source = new BitmapImage(new Uri(thirdMonsters.Images));
            ThirdMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(thirdMonsters.Vulnerability)];
            ThirdMonsterPower.Content = thirdMonsters.Name;
            ThirdMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[thirdMonsters.Power];

            fourthMonsters = Monsters[3];
            FourthImageMonster.Source = new BitmapImage(new Uri(fourthMonsters.Images));
            FourthMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(fourthMonsters.Vulnerability)];
            FourthMonsterPower.Content = fourthMonsters.Name;
            FourthMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[fourthMonsters.Power];
        }

        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.Healt, firstMonsters.Armor);
                if (FirstHealtBarMonster.Width - damage < 0)
                {
                    Turn.RemoveTurn("First");
                    FirstHealtBarMonster.Width = 0;
                    FirstMonster.Children.Clear();
                    NeedMetod.DeadMonsters(firstMonsters.EXP);
                }
                else
                {
                    FirstHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }

        private void SecondMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(SecondHealtMaxBarMonster.Width, secondMonsters.Healt, secondMonsters.Armor);
                if (SecondHealtBarMonster.Width - damage < 0)
                {
                    Turn.RemoveTurn("Second");
                    SecondHealtBarMonster.Width = 0;
                    SecondMonster.Children.Clear();
                    NeedMetod.DeadMonsters(secondMonsters.EXP);
                }
                else
                {
                    SecondHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }

        private void ThirdMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(ThirdHealtMaxBarMonster.Width, thirdMonsters.Healt, thirdMonsters.Armor);
                if (ThirdHealtBarMonster.Width - damage < 0)
                {
                    Turn.RemoveTurn("Third");
                    ThirdHealtBarMonster.Width = 0;
                    ThirdMonster.Children.Clear();
                    NeedMetod.DeadMonsters(secondMonsters.EXP);
                }
                else
                {
                    ThirdHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }

        private void FourthMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(FourthHealtMaxBarMonster.Width, fourthMonsters.Healt, fourthMonsters.Armor);
                if (FourthHealtBarMonster.Width - damage < 0)
                {
                    Turn.RemoveTurn("Fourth");
                    FourthHealtBarMonster.Width = 0;
                    FourthMonster.Children.Clear();
                    NeedMetod.DeadMonsters(secondMonsters.EXP);
                }
                else
                {
                    FourthHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
