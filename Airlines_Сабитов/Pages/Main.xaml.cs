using System;
using System.Windows;
using System.Windows.Controls;

namespace Airlines_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Hide(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDepartureDate = startDate.SelectedDate;
            DateTime? selectedReturnDate = wayDate.SelectedDate;
            mainWindow.frame.Navigate(new Ticket(mainWindow, from.Text, to.Text, selectedDepartureDate, selectedReturnDate));
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
