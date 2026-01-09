using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airlines_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        MainWindow mainWindow;
        public Ticket(MainWindow window, string from, string to)
        {
            InitializeComponent();
            mainWindow = window;
            parrent.Children.Add(new Elements.Item());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Main(mainWindow));
        }
    }
}
