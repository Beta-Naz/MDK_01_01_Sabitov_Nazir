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
            Classes.CreateLocations.LastLocation = name;
            Classes.CreateLocations.LastLocationSourse = sourse;
            WorldMap.init.Confirmation.Children.Clear();
            Classes.AddMonster.AddBatlle();
        }
    }
}
