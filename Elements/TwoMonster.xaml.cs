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
        public TwoMonster(Classes.AlwaysMonsters FirstMonsters, Classes.AlwaysMonsters SecondMonsters)
        {
            InitializeComponent();
            init = this;

            firstMonsters = FirstMonsters;
            FirstImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            FirstMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(firstMonsters.Vulnerability)];
            FirstMonsterPower.Content = firstMonsters.Name;
            FirstMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[firstMonsters.Power];

            secondMonsters = SecondMonsters;
            SecondImageMonster.Source = new BitmapImage(new Uri(secondMonsters.Images));
            SecondMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
                [NeedMetod.SelectVulnerability(secondMonsters.Vulnerability)];
            SecondMonsterPower.Content = secondMonsters.Name;
            SecondMonsterPower.Foreground = NeedMetod.PowerAndVulnerabilityMonster[secondMonsters.Power];
        }

        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            double damage = NeedMetod.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.Healt, firstMonsters.Armor);
            if (FirstHealtBarMonster.Width - damage < 0)
            {
                FirstHealtBarMonster.Width = 0;
                FirstMonster.Children.Clear();
                NeedMetod.DeadMonsters(firstMonsters.EXP);
            }
            else
            {
                FirstHealtBarMonster.Width -= damage;
            }
        }

        private void SecondMonster_Click(object sender, MouseButtonEventArgs e)
        {
            double damage = NeedMetod.MinusHealt(SecondHealtMaxBarMonster.Width, secondMonsters.Healt, secondMonsters.Armor);
            if (SecondHealtBarMonster.Width - damage < 0)
            {
                SecondHealtBarMonster.Width = 0;
                SecondMonster.Children.Clear();
                NeedMetod.DeadMonsters(secondMonsters.EXP);
            }
            else
            {
                SecondHealtBarMonster.Width -= damage;
            }
        }
    }
}
