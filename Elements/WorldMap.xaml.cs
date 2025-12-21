using Batlle_Сабитов.Classes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            ResetSelectLocations(Classes.Metod.Variables.SelectLocation);
            init = this;
        }
        private void Zamok_Click(object sender, MouseButtonEventArgs e)
        {
            AddMonster.AddZamok();
        }
        private void SpecificationsAndStore_Click(object sender, MouseButtonEventArgs e)
        {
            AddMonster.AddSpecificationsAndStore();
        }
        public void ResetSelectLocations(int[] x)
        {
            var locations = new[]
            {
                Zamok,
                Forest,
                DarkForest,
                Swamp,
                DeadForest,
                Dune
            };

            for (int i = 0; i < locations.Length; i++)
            {
                bool shouldReset = false;
                for (int j = 0; j < x.Length; j++)
                {
                    if (x[j] == i) 
                    {
                        shouldReset = true;
                        break;
                    }
                }
                if (shouldReset)
                {
                    locations[i].Fill = new SolidColorBrush(Colors.Transparent);
                    locations[i].Cursor = Cursors.Hand;
                }
                else
                {
                    locations[i].Cursor = Cursors.No;
                    locations[i].Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#80666666"));
                }
            }
        }
        private void Forest_Click(object sender, MouseButtonEventArgs e)
        {
            if(!Classes.Locations.CreateLocations.AllowedLocations.Contains($"{Classes.Locations.RepoAllLocations.AllLocations()[0].NameLocations}"))
            {
                return;
            }
            Classes.AlwaysMonsters.ChanceCountSpawnMonster = new int[] { 60, 30};

            Classes.Metod.SpawnMonsters.ResetWhatSpawnMosters(Classes.Locations.RepoAllLocations.AllLocations()[0].NameLocations);

            Confirmation.Children.Add(new Elements.Confirmation(Classes.Locations.RepoAllLocations.AllLocations()[0].NameLocations,
                Classes.Locations.RepoAllLocations.AllLocations()[0].BackgroundLocations));
        }
        private void DarkForest_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.Locations.CreateLocations.AllowedLocations.Contains($"{Classes.Locations.RepoAllLocations.AllLocations()[1].NameLocations}"))
            {
                return;
            }
            Classes.AlwaysMonsters.ChanceCountSpawnMonster = new int[] { 35, 40};

            Classes.Metod.SpawnMonsters.ResetWhatSpawnMosters(Classes.Locations.RepoAllLocations.AllLocations()[1].NameLocations);

            Confirmation.Children.Add(new Elements.Confirmation(Classes.Locations.RepoAllLocations.AllLocations()[1].NameLocations,
                Classes.Locations.RepoAllLocations.AllLocations()[1].BackgroundLocations));
        }
        private void Swamp_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.Locations.CreateLocations.AllowedLocations.Contains($"{Classes.Locations.RepoAllLocations.AllLocations()[2].NameLocations}"))
            {
                return;
            }

            Classes.Metod.SpawnMonsters.ResetWhatSpawnMosters(Classes.Locations.RepoAllLocations.AllLocations()[2].NameLocations);

            Classes.AlwaysMonsters.ChanceCountSpawnMonster = new int[] { 25, 30};
            Confirmation.Children.Add(new Elements.Confirmation(Classes.Locations.RepoAllLocations.AllLocations()[2].NameLocations,
                Classes.Locations.RepoAllLocations.AllLocations()[2].BackgroundLocations));
        }
        private void DeadForest_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.Locations.CreateLocations.AllowedLocations.Contains($"{Classes.Locations.RepoAllLocations.AllLocations()[3].NameLocations}"))
            {
                return;
            }

            Classes.Metod.SpawnMonsters.ResetWhatSpawnMosters(Classes.Locations.RepoAllLocations.AllLocations()[3].NameLocations);

            Classes.AlwaysMonsters.ChanceCountSpawnMonster = new int[] { 10, 25};
            Confirmation.Children.Add(new Elements.Confirmation(Classes.Locations.RepoAllLocations.AllLocations()[3].NameLocations,
                Classes.Locations.RepoAllLocations.AllLocations()[3].BackgroundLocations));
        }
        private void Dune_Click(object sender, MouseButtonEventArgs e)
        {
            if (!Classes.Locations.CreateLocations.AllowedLocations.Contains($"{Classes.Locations.RepoAllLocations.AllLocations()[4].NameLocations}"))
            {
                return;
            }

            Classes.Metod.SpawnMonsters.ResetWhatSpawnMosters(Classes.Locations.RepoAllLocations.AllLocations()[4].NameLocations);

            Classes.AlwaysMonsters.ChanceCountSpawnMonster = new int[] { 1, 10};
            Confirmation.Children.Add(new Elements.Confirmation(Classes.Locations.RepoAllLocations.AllLocations()[4].NameLocations,
                Classes.Locations.RepoAllLocations.AllLocations()[4].BackgroundLocations));
        }
    }
}
