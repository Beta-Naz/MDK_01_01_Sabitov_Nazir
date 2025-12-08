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
using static Documents_Сабитов.MainWindow;

namespace Documents_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public List<Model.DocumentContext> AllDocuments = new Classes.DocumentContext().AllDocument();
        public List<Model.User> AllUsers = new Classes.UserContext().AllUser();

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(pages.mainDocument);
        }
        public enum pages
        {
            mainDocument,
            addDocument,
            mainUser,
            addUser
        }
        public void OpenPages(pages _pages)
        {
            if(_pages == pages.mainDocument)
            {
                frame.Navigate(new Pages.DocumentPages.Main());
            }
            else if(_pages == pages.addDocument)
            {
                frame.Navigate(new Pages.DocumentPages.Add());
            }
            else if (_pages == pages.mainUser)
            {
                frame.Navigate(new Pages.UserPages.Main());
            }
            else if (_pages == pages.addUser)
            {
                frame.Navigate(new Pages.UserPages.Add());
            }
        }
    }
}
