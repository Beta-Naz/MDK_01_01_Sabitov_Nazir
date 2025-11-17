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
using PrintManagementSystem_Сабитов.Classes;
using static PrintManagementSystem_Сабитов.MainWindow;

namespace PrintManagementSystem_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<TypeOperationsWindow> operations = new List<TypeOperationsWindow>();
        public MainWindow()
        {
            InitializeComponent();
            OpenLayot(pages.journal);
        }

        public enum pages
        {
            journal,
            createOperations
        }
        public void OpenLayot(pages _pages)
        {
            switch (_pages)
            {
                case pages.journal:
                    frame.Navigate(new Layots.Journal(this));
                    break;
                case pages.createOperations: 
                    frame.Navigate(new Layots.CreateOperations(this)); 
                    break;
            }
        }
    }
}
