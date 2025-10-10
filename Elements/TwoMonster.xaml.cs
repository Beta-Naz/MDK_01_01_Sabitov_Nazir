using Batlle_Сабитов.Classes;
using System;
using System.Collections.Generic;
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
using System.Timers;
using System.Threading;

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

            NeedMetod.death = 2;

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
        }

        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.Healt, firstMonsters.Armor);
                if (FirstHealtBarMonster.Width - damage < 0)
                {
                    FirstHealtBarMonster.Width = 0;
                    NeedMetod.DeadMonsters(firstMonsters.EXP);
                    Turn.RemoveTurn("First");
                    FirstMonster.Children.Clear();
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
                    SecondHealtBarMonster.Width = 0;
                    NeedMetod.DeadMonsters(secondMonsters.EXP);
                    Turn.RemoveTurn("Second");
                    SecondMonster.Children.Clear();
                }
                else
                {
                    SecondHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
