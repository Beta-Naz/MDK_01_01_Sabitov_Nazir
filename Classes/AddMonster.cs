using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes
{
    public class AddMonster
    {
        public static void AddBatlle()
        {
            Batlle_Сабитов.MainWindow.init.MinWidth = 800;
            Batlle_Сабитов.MainWindow.init.Width = 800;
            Batlle_Сабитов.MainWindow.init.MinHeight = 500;
            Batlle_Сабитов.MainWindow.init.MinHeight = 500;
            MainWindow.init.MainGameWindow.Children.Clear();
            MainWindow.init.MainGameWindow.Children.Add(new Elements.Batlle());
        }
        public static void AddZamok()
        {
            Batlle_Сабитов.MainWindow.init.MinWidth = 900;
            Batlle_Сабитов.MainWindow.init.Width = 900;
            Batlle_Сабитов.MainWindow.init.MinHeight = 450;
            Batlle_Сабитов.MainWindow.init.MinHeight = 450;
            MainWindow.init.MainGameWindow.Children.Clear();
            MainWindow.init.MainGameWindow.Children.Add(new Elements.UserGameWindow());
        }
        public static void AddСhoiceCharacter()
        {
            MainWindow.init.MainGameWindow.Children.Clear();
            MainWindow.init.MainGameWindow.Children.Add(new Elements.UserGameWindow());
        }
        public static void AddWorldMap()
        {
            MainWindow.init.MainGameWindow.Children.Clear();
            if(CreateLocations.LastLocation == RepoAllLocations.AllLocations()[4].NameLocations)
            {
                CreateLocations.LastLocation = RepoAllLocations.AllLocations()[5].NameLocations;
                CreateLocations.LastLocationSourse = RepoAllLocations.AllLocations()[5].BackgroundLocations;
                AddBatlle();
                return;
            }
            if(CreateLocations.LastLocation == RepoAllLocations.AllLocations()[0].NameLocations)
            {
                CreateLocations.AllowedLocations[2] = $"{RepoAllLocations.AllLocations()[1].NameLocations}";
            }
            else if(CreateLocations.LastLocation == RepoAllLocations.AllLocations()[1].NameLocations)
            {
                CreateLocations.AllowedLocations = NeedMetod.CalculateAllowedLocations(RepoAllLocations.AllLocations()[1].NameLocations,
                    RepoAllLocations.AllLocations()[2].NameLocations);
            }
            else if (CreateLocations.LastLocation == RepoAllLocations.AllLocations()[2].NameLocations)
            {
                CreateLocations.AllowedLocations = NeedMetod.CalculateAllowedLocations(RepoAllLocations.AllLocations()[2].NameLocations,
                    RepoAllLocations.AllLocations()[3].NameLocations);
            }
            else if (CreateLocations.LastLocation == RepoAllLocations.AllLocations()[3].NameLocations)
            {
                CreateLocations.AllowedLocations = NeedMetod.CalculateAllowedLocations(RepoAllLocations.AllLocations()[3].NameLocations,
                    RepoAllLocations.AllLocations()[4].NameLocations);
            }
            MainWindow.init.MainGameWindow.Children.Add(new Elements.WorldMap());
        }
    }
}
