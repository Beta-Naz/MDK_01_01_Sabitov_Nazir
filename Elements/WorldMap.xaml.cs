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
    /// Логика взаимодействия для WorldMap.xaml
    /// </summary>
    public partial class WorldMap : UserControl
    {
        public static WorldMap init;
        public WorldMap()
        {
            InitializeComponent();
            init = this;
        }
        private void Zamok_Click(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void SpecificationsAndStore_Click(object sender, MouseButtonEventArgs e)
        {

        }
        private void Forest_Click(object sender, MouseButtonEventArgs e)
        {
            if(!Classes.CreateLocations.AllowedLocations.Contains($"{Classes.RepoAllLocations.AllLocations()[0].NameLocations}"))
            {
                return;
            }
            Confirmation.Children.Add(new Elements.Confirmation(Classes.RepoAllLocations.AllLocations()[0].NameLocations,
                Classes.RepoAllLocations.AllLocations()[0].BackgroundLocations));
        }
        private void DarkForest_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.CreateLocations.AllowedLocations.Contains($"{Classes.RepoAllLocations.AllLocations()[1].NameLocations}"))
            {
                return;
            }
            Confirmation.Children.Add(new Elements.Confirmation(Classes.RepoAllLocations.AllLocations()[1].NameLocations,
                Classes.RepoAllLocations.AllLocations()[1].BackgroundLocations));
        }
        private void Swamp_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.CreateLocations.AllowedLocations.Contains($"{Classes.RepoAllLocations.AllLocations()[2].NameLocations}"))
            {
                return;
            }
            Confirmation.Children.Add(new Elements.Confirmation(Classes.RepoAllLocations.AllLocations()[2].NameLocations,
                Classes.RepoAllLocations.AllLocations()[2].BackgroundLocations));
        }
        private void DeadForest_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.CreateLocations.AllowedLocations.Contains($"{Classes.RepoAllLocations.AllLocations()[3].NameLocations}"))
            {
                return;
            }
            Confirmation.Children.Add(new Elements.Confirmation(Classes.RepoAllLocations.AllLocations()[3].NameLocations,
                Classes.RepoAllLocations.AllLocations()[3].BackgroundLocations));
        }
        private void Dune_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.CreateLocations.AllowedLocations.Contains($"{Classes.RepoAllLocations.AllLocations()[4].NameLocations}"))
            {
                return;
            }
            Confirmation.Children.Add(new Elements.Confirmation(Classes.RepoAllLocations.AllLocations()[4].NameLocations,
                Classes.RepoAllLocations.AllLocations()[4].BackgroundLocations));
        }
    }
}
