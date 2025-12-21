using System.Windows;
using System.Windows.Controls;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }
    }
}
