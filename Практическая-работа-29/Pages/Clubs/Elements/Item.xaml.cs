using System.Windows.Controls;
using Практическая_работа_29.Models;

namespace Практическая_работа_29.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private Main _currentMain;
        private Club? _currentClub;
        public Item(Club club, Main main)
        {
            InitializeComponent();
            if(club == null)
            {
                return;
            }
            _currentMain = main;
            _currentClub = club;
        }
        public void LoadDate()
        {
            if(_currentClub == null)
            {
                return;
            }
            Name.Text = _currentClub.Name;
            Address.Text = _currentClub.Address;
            WorkTime.Text = _currentClub.WorkTime;
        }

        private void EditClub(object sender, System.Windows.RoutedEventArgs e)
        {
            if(MainWindow.Instance == null || _currentClub == null)
            {
                return;
            }
            MainWindow.Instance.OpenPages(new Add(_currentMain, _currentClub));
        }

        private void DeleteClub(object sender, System.Windows.RoutedEventArgs e)
        {
            if(_currentClub == null)
            {
                return;
            }
            _currentMain.AllClub.Clubs.Remove(_currentClub);
            _currentMain.AllClub.SaveChanges();
            _currentMain.Parent.Children.Remove(this);
        }
    }
}
