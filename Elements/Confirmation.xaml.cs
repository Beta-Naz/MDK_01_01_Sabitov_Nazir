using System.Windows;
using System.Windows.Controls;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Confirmation.xaml
    /// </summary>
    public partial class Confirmation : UserControl
    {
        public string name;
        public string sourse;
        public Confirmation(string name, string sourse)
        {
            InitializeComponent();
            NameLocation.Content = name;
            this.name = name;
            this.sourse = sourse;
        }
        private void No_Click(object sender, RoutedEventArgs e)
        {
            WorldMap.init.Confirmation.Children.Clear();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Classes.Locations.CreateLocations.LastLocation = name;
            Classes.Locations.CreateLocations.LastLocationSourse = sourse;
            WorldMap.init.Confirmation.Children.Clear();
            Classes.AddMonster.AddBatlle();
        }
    }
}
