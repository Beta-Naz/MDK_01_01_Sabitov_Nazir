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
    /// Логика взаимодействия для Boss.xaml
    /// </summary>
    public partial class Boss : UserControl
    {
        AlwaysMonsters firstMonsters;
        public Boss(AlwaysMonsters Boss)
        {
            InitializeComponent();
            Classes.Metod.Variables.death = 1;
            firstMonsters = Boss;
            FirstMonsterBorder.BorderBrush = Classes.Metod.Variables.PowerAndVulnerabilityMonster
                [Classes.Metod.AttackAndProtection.SelectVulnerability(firstMonsters.Vulnerability)];
            ImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            OneMonstrPower.Content = firstMonsters.Name;
            Batlle.init.BossHealt.Children.Add(new Elements.StripOfLifeToBoss(Boss));
        }
        private void Boss_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                (double damageForBar, double damageForHealt) = Classes.Metod.AttackAndProtection.MinusHealt(StripOfLifeToBoss.init.HealtMaxBarBoss.Width, firstMonsters.MaxHealt, firstMonsters.Armor, firstMonsters.Vulnerability);
                if (StripOfLifeToBoss.init.HealtBarBoss.Width - damageForBar < 0)
                {
                    Classes.Metod.Variables.death--;
                    StripOfLifeToBoss.init.HealtBarBoss.Width = 0;
                    StripOfLifeToBoss.init.TextHealtBoss.Content = 0;
                    Classes.Metod.SwitchingLocations.DeadMonsters(firstMonsters.EXP, firstMonsters.Money);
                }
                else
                {
                    firstMonsters.Healt -= damageForHealt;
                    StripOfLifeToBoss.init.HealtBarBoss.Width -= damageForBar;
                    StripOfLifeToBoss.init.TextHealtBoss.Content = Math.Round(firstMonsters.Healt,0);
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
