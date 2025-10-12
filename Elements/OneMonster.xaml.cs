using Batlle_Сабитов.Classes;
using System;
using System.Collections;
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
    /// Логика взаимодействия для OneMonster.xaml
    /// </summary>
    public partial class OneMonster : UserControl
    {
        AlwaysMonsters firstMonsters;
        public OneMonster(List<Classes.AlwaysMonsters> Monsters)
        {
            InitializeComponent();

            Classes.Metod.Variables.death = 1;
            firstMonsters = Monsters[0];
            FirstMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(firstMonsters.Vulnerability)];
            ImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            OneMonstrPower.Content = firstMonsters.Name;
            OneMonstrPower.Foreground = Classes.Metod.Variables.PowerAndVulnerabilityMonster[firstMonsters.Power];
            TextHealtFirst.Content = firstMonsters.Healt;
        }
        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.MaxHealt, firstMonsters.Armor, firstMonsters.Vulnerability);
                if (FirstHealtBarMonster.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    TextHealtFirst.Content = 0;
                    FirstHealtBarMonster.Width = 0;
                    Classes.Metod.SwitchingLocations.DeadMonsters(firstMonsters.EXP, firstMonsters.Money);
                }
                else
                {
                    firstMonsters.Healt -= damageForHealt;
                    FirstHealtBarMonster.Width -= damageForBar;
                    TextHealtFirst.Content = Math.Round(firstMonsters.Healt,0);
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
