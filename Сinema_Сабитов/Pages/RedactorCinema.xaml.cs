using System.Windows.Controls;

namespace Сinema_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для RedactorCinema.xaml
    /// </summary>
    public partial class RedactorCinema : Page
    {
        MainWindow mainWindow;
        public RedactorCinema(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void SearchPanel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ClearFilter(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void ApplyFilter(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
