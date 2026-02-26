using System.Windows;
using System.Windows.Controls;
using Практическая_работа_29.Models;

namespace Практическая_работа_29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Main _currentMain;
        private Club? _currentClub;
        public Add(Main main, Club? club = null)
        {
            InitializeComponent();
            if (club != null)
            {
                _currentClub = club;
                LoadDate();
            }
            _currentMain = main;
        }
        public void LoadDate()
        {
            if (_currentClub == null)
            {
                return;
            }
            Name.Text = _currentClub.Name;
            Address.Text = _currentClub.Address;
            WorkTime.Text = _currentClub.WorkTime;
            BtnEdit.Content = "Изменить";
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance == null)
            {
                return;
            }
            MainWindow.Instance.OpenPages(_currentMain);
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неверный формат имени", "Ошибка инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(Address.Text))
            {
                MessageBox.Show("Неверный формат адреса", "Ошибка инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(WorkTime.Text))
            {
                MessageBox.Show("Неверный формат времени работы", "Ошибка инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string[] date = WorkTime.Text.Trim().Split('-');
            if (date.Length != 2)
            {
                MessageBox.Show("Неверный формат времени работы (00:00 - 00.00)", "Ошибка инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if(!TimeSpan.TryParse(date[0].Trim(), out _) || !TimeSpan.TryParse(date[1].Trim(), out _))
            {
                MessageBox.Show("Неверный формат времени работы (00:00 - 00.00)", "Ошибка инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_currentClub == null)
            {
                _currentClub = new Club() 
                {
                    Name = Name.Text,
                    Address = Address.Text,
                    WorkTime = WorkTime.Text
                };
                _currentMain.AllClub.Clubs.Add(_currentClub);
            }
            else
            {
                _currentClub.Name = Name.Text;
                _currentClub.Address = Address.Text;
                _currentClub.WorkTime = WorkTime.Text;
            }
            _currentMain.AllClub.SaveChanges();
            MainWindow.Instance.OpenPages(new Main());
        }
    }
}
