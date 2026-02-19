using ComputerClub_Сабитов.Core.Context;
using ComputerClub_Сабитов.Core.Enums;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ComputerClub_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private MainWindow _currentMainWindow;
        private MainMenu _currentMainMenu;
        private object _currentObject = null;
        public AddPage(MainWindow mainWindow, object obj = null, MainMenu main = null)
        {
            InitializeComponent();
            _currentMainWindow = mainWindow;
            if(obj != null)
            {
                _currentObject = obj;
                if (obj is ContextCompiterClub club)
                {
                    Name.Text = club.Name.ToString();
                    StartDate.Text = club.StartTimeWork.ToString("dd,MM,yyyy");
                    EndDate.Text = club.EndTimeWork.ToString("dd,MM,yyyy");
                    StartTime.Text = club.StartTimeWork.ToString("t");
                    EndDate.Text = club.StartTimeWork.ToString("t");
                    Address.Text = club.Address.ToString();
                }
                else if (obj is ContextPlayerComputer player)
                {
                    Name.Text = player.FullName.ToString();
                    StartDate.Text = player.StartTimeRent.ToString("dd,MM,yyyy");
                    EndDate.Text = player.EndTimeRent.ToString("dd,MM,yyyy");
                    StartTime.Text = player.StartTimeRent.ToString("t");
                    EndDate.Text = player.StartTimeRent.ToString("t");
                    parrent.Children.Remove(AddressPanel);
                }
            }
        }

        private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentMainWindow.LoadPages(PageType.mainPage);
        }

        private void SaveOrEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show($"Напишите нормальное имя", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(StartDate.Text) || !DateTime.TryParse(StartDate.Text, out _))
            {
                MessageBox.Show($"Напишите правильно дату начала", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(EndDate.Text) || !DateTime.TryParse(EndDate.Text, out _))
            {
                MessageBox.Show($"Напишите правильно дату окончания", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(StartTime.Text) || !TimeSpan.TryParse(StartTime.Text, out _))
            {
                MessageBox.Show($"Напишите правильно время начала (00:00)", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(EndTime.Text) || !TimeSpan.TryParse(EndTime.Text, out _))
            {
                MessageBox.Show($"Напишите правильно время окончания (00:00)", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (StartDate != null && string.IsNullOrEmpty(StartDate.Text))
            {
                MessageBox.Show($"Напишите правильно адрес", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
