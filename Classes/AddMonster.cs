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
        public static void AddSpecificationsAndStore()
        {
            Batlle_Сабитов.MainWindow.init.MinWidth = 900;
            Batlle_Сабитов.MainWindow.init.Width = 900;
            Batlle_Сабитов.MainWindow.init.MinHeight = 550;
            Batlle_Сабитов.MainWindow.init.MinHeight = 550;
            MainWindow.init.MainGameWindow.Children.Clear();
            MainWindow.init.MainGameWindow.Children.Add(new Elements.SpecificationsAndStore());
        }
        public static void AddСhoiceCharacter()
        {
            MainWindow.init.MainGameWindow.Children.Clear();
            MainWindow.init.MainGameWindow.Children.Add(new Elements.UserGameWindow());
        }
        public static void AddWorldMap()
        {
            MainWindow.init.MainGameWindow.Children.Clear();
            if (Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[5].NameLocations)
            {
                Batlle_Сабитов.MainWindow.init.MinWidth = 900;
                Batlle_Сабитов.MainWindow.init.Width = 900;
                Batlle_Сабитов.MainWindow.init.MinHeight = 570;
                Batlle_Сабитов.MainWindow.init.MinHeight =570;
                Victory();
                return;
            }
            if (Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[4].NameLocations)
            {
                Classes.Locations.CreateLocations.LastLocation = Classes.Locations.RepoAllLocations.AllLocations()[Locations.RepoAllLocations.AllLocations().Count - 1].NameLocations;
                Locations.CreateLocations.LastLocation = Locations.RepoAllLocations.AllLocations()[5].NameLocations;
                Locations.CreateLocations.LastLocationSourse = Locations.RepoAllLocations.AllLocations()[5].BackgroundLocations;
                AddBatlle();
                return;
            }
            if(Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[0].NameLocations)
            {
                Locations.CreateLocations.AllowedLocations[2] = $"{Locations.RepoAllLocations.AllLocations()[1].NameLocations}";
                Classes.Metod.Variables.SelectLocation = new int[] { 0, 1, 2 };
            }
            else if(Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[1].NameLocations)
            {
                Locations.CreateLocations.AllowedLocations = Metod.SwitchingLocations.CalculateAllowedLocations(Locations.RepoAllLocations.AllLocations()[1].NameLocations,
                    Locations.RepoAllLocations.AllLocations()[2].NameLocations);
                Classes.Metod.Variables.SelectLocation =  new int[] { 2,3 };
            }
            else if (Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[2].NameLocations)
            {
                Locations.CreateLocations.AllowedLocations = Metod.SwitchingLocations.CalculateAllowedLocations(Locations.RepoAllLocations.AllLocations()[2].NameLocations,
                    Locations.RepoAllLocations.AllLocations()[3].NameLocations);
                Classes.Metod.Variables.SelectLocation =  new int[] { 3, 4 };
            }
            else if (Locations.CreateLocations.LastLocation == Locations.RepoAllLocations.AllLocations()[3].NameLocations)
            {
                Locations.CreateLocations.AllowedLocations = Metod.SwitchingLocations.CalculateAllowedLocations(Locations.RepoAllLocations.AllLocations()[3].NameLocations,
                    Locations.RepoAllLocations.AllLocations()[4].NameLocations);
                Classes.Metod.Variables.SelectLocation = new int[] { 4, 5 };
            }
            MainWindow.init.MainGameWindow.Children.Add(new Elements.WorldMap());
        }
        public static void Victory()
        {
            MainWindow.init.MainGameWindow.Children.Add(new Elements.PeacefulWorld());
        }
    }
}
