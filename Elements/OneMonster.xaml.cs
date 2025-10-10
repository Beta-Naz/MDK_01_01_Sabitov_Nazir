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

            NeedMetod.death = 1;

            firstMonsters = Monsters[0];
            FirstMonsterBorder.BorderBrush = NeedMetod.PowerAndVulnerabilityMonster
    [NeedMetod.SelectVulnerability(firstMonsters.Vulnerability)];
            ImageMonster.Source = new BitmapImage(new Uri(firstMonsters.Images));
            OneMonstrPower.Content = firstMonsters.Name;
        }
        private void FirstMonster_Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.ValidAttack)
            {
                double damage = NeedMetod.MinusHealt(FirstHealtMaxBarMonster.Width, firstMonsters.Healt, firstMonsters.Armor);
                if (FirstHealtBarMonster.Width - damage < 0)
                {
                    FirstHealtBarMonster.Width = 0;
                    AddMonster.AddWorldMap();
                }
                else
                {
                    FirstHealtBarMonster.Width -= damage;
                }
                Batlle.СhangeTurn();
            }
        }
    }
}
