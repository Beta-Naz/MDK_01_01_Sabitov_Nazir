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
            _currentMainMenu = main;
            if (obj != null)
            {
                _currentObject = obj;
                if (obj is ContextCompiterClub club)
                {
                    Name.Text = club.Name.ToString();
                    StartDate.Text = club.StartTimeWork.ToString("dd.MM.yyyy");
                    EndDate.Text = club.EndTimeWork.ToString("dd.MM.yyyy");
                    StartTime.Text = club.StartTimeWork.ToString("t");
                    EndTime.Text = club.StartTimeWork.ToString("t");
                    Address.Text = club.Address.ToString();
                }
                else if (obj is ContextPlayerComputer player)
                {
                    Name.Text = player.FullName.ToString();
                    StartDate.Text = player.StartTimeRent.ToString("dd.MM.yyyy");
                    EndDate.Text = player.EndTimeRent.ToString("dd.MM.yyyy");
                    StartTime.Text = player.StartTimeRent.ToString("t");
                    EndTime.Text = player.StartTimeRent.ToString("t");
                    parrent.Children.Remove(AddressPanel);
                }
            }
            else if (_currentMainMenu != null && !_currentMainMenu.Change)
            {
                parrent.Children.Remove(AddressPanel);
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
            if (string.IsNullOrEmpty(StartTime.Text) || !TimeSpan.TryParse(StartTime.Text, out _) || !DateTime.TryParse(StartDate.Text + " " + StartTime.Text, out _))
            {
                MessageBox.Show($"Напишите правильно время начала (00:00)", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(EndTime.Text) || !TimeSpan.TryParse(EndTime.Text, out _) || !DateTime.TryParse(EndDate.Text + " " + EndTime.Text, out _))
            {
                MessageBox.Show($"Напишите правильно время окончания (00:00)", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_currentObject is ContextCompiterClub && string.IsNullOrEmpty(Address.Text))
            {
                MessageBox.Show($"Напишите правильно адрес", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (DateTime.Parse(StartDate.Text + " " + StartTime.Text) <= DateTime.Parse(EndDate.Text + " " + EndTime.Text))
            {
                MessageBox.Show($"Дата окончания больше чем дата начала", "Инкапсуляции", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            object obj = _currentObject;
            if (obj == null)
            {
                if(_currentMainMenu == null)
                {
                    MessageBox.Show($"Error text: _currentMainMenu == null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (_currentMainMenu.Change)
                {
                    obj = new ContextCompiterClub();
                }
                else 
                {
                    obj = new ContextPlayerComputer();
                }
            }
            if (obj is ContextCompiterClub club)
            {
                club.Name = Name.Text;
                club.StartTimeWork = DateTime.Parse(StartDate.Text + " " + StartTime.Text);
                club.EndTimeWork = DateTime.Parse(EndDate.Text + " " + EndTime.Text);
                club.Address = Address.Text;
                club.Save(_currentObject != null);
            }
            else if (obj is ContextPlayerComputer player)
            {
                player.FullName = Name.Text;
                player.StartTimeRent = DateTime.Parse(StartDate.Text + " " + StartTime.Text);
                player.EndTimeRent = DateTime.Parse(EndDate.Text + " " + EndTime.Text);
                player.Save(_currentObject != null);
            }
            _currentMainWindow.LoadPages(PageType.mainPage);
        }
    }
}
