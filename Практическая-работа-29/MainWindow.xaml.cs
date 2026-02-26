using System.Windows;
using System.Windows.Controls;

namespace Практическая_работа_29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPages(new Pages.Clubs.Main());
        }
        public void OpenPages(Page page)
        {
            frame.Navigate(page);
        }
        private void SelectUser_Click(object sender, RoutedEventArgs e)
        {
            OpenPages(new Pages.Users.Main());
        }

        private void SelectClub_Click(object sender, RoutedEventArgs e)
        {
            OpenPages(new Pages.Clubs.Main());
        }
    }
}