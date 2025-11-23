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

namespace FurnitureStore_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(pages.main, "All");
        }
        public enum pages
        {
            main,
            categor
        }
        public void OpenPages(pages page, string type)
        {
            switch (page)
            {
                case pages.main:  
                    frame.Navigate(new Pages.Main(type));
                    break;
                case pages.categor:
                    frame.Navigate(new Pages.Categor()); 
                    break;
            }
        }
    }
}
