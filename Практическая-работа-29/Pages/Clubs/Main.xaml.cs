using System.Windows;
using System.Windows.Controls;
using Практическая_работа_29.Classes.Context;

namespace Практическая_работа_29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubContext AllClub = new ClubContext();
        public Main()
        {
            InitializeComponent();
            LoadDate();
        }
        public void LoadDate()
        {
            foreach (Models.Club club in AllClub.Clubs)
            {
                Parent.Children.Add(new Elements.Item(club, this));
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.Instance == null)
            {
                return;
            }
            MainWindow.Instance.OpenPages(new Add(this));
        }
    }
}
