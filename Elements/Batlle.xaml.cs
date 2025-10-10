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
    /// Логика взаимодействия для Batlle.xaml
    /// </summary>
    public partial class Batlle : UserControl
    {
        public static Batlle init;
        public Batlle()
        {
            InitializeComponent();
            init = this;
            AddMonster.AddOneMonster(RepoAlwaysMonsters.AllMonster()[0]);
            PlayerHealt.Content = $"Здоровье: {Player.Healt}/{Player.MaxHealt}";
            PlayerDamage.Content = $"Урон: " + Player.Damage;
            PlayerDexterity.Content = $"Ловкость: " + Player.Dexterity;
            PlayerEXP.Content = $"Опыт:  " + Player.EXP;
            PlayerImages.Source = new BitmapImage(new Uri(Player.Images));
            PlayerName.Content = Player.Name;
            PlayerName.Foreground = NeedMetod.Color[Player.ColorName];
            BackGround.Source = new BitmapImage(new Uri(CreateLocations.LastLocationSourse));
        }
        private void Player_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
