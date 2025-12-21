using Batlle_Сабитов.Classes;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
                double damage = Classes.Metod.AttackAndProtection.MinusHealt(firstMonsters.Armor, firstMonsters.Vulnerability);
                if (firstMonsters.Healt - damage <= 0)
                {
                    Classes.Metod.Variables.death--;
                    StripOfLifeToBoss.init.HealtBarBoss.Width = 0;
                    firstMonsters.Healt = 0;
                    StripOfLifeToBoss.init.TextHealtBoss.Content = 0;
                    Classes.Metod.SwitchingLocations.DeadMonsters(firstMonsters.EXP, firstMonsters.Money);
                }
                else
                {
                    firstMonsters.Healt -= damage;
                    StripOfLifeToBoss.init.HealtBarBoss.Width = (firstMonsters.Healt / firstMonsters.MaxHealt) * StripOfLifeToBoss.init.HealtMaxBarBoss.Width;
                    StripOfLifeToBoss.init.TextHealtBoss.Content = Math.Round(firstMonsters.Healt,0);
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
