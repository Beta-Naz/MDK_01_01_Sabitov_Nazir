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
using Documents_Сабитов.Classes;
using Documents_Сабитов.Model;

namespace Documents_Сабитов.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            CreatedUI();
        }
        public void CreatedUI()
        {
            parrent.Children.Clear();
            MainWindow.init.AllUsers = new Classes.UserContext().AllUser();
            foreach (Classes.UserContext user in MainWindow.init.AllUsers)
            {
                parrent.Children.Add(new Elements.User.Item(user));
            }
        }
        private void Add(object sender, RoutedEventArgs e) =>
            MainWindow.init.frame.Navigate(new Pages.UserPages.Add());

        private void Exit(object sender, RoutedEventArgs e) =>
            MainWindow.init.Close();

        private void scroll(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.DocumentPages.Main());
        }
    }
}
