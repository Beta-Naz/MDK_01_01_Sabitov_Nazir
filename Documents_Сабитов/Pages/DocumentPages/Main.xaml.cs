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

namespace Documents_Сабитов.Pages.DocumentPages
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
            foreach (DocumentContext document in MainWindow.init.AllDocuments)
            {
                parrent.Children.Add(new Elements.Document.Item(document));
            }
        }
        private void Add(object sender, RoutedEventArgs e) =>
            MainWindow.init.frame.Navigate(new Pages.DocumentPages.Add());

        private void Exit(object sender, RoutedEventArgs e) =>
            MainWindow.init.Close();

        private void scroll(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.UserPages.Main());
        }
    }
}
