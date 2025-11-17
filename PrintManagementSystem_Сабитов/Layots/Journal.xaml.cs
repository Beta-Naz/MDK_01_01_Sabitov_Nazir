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

namespace PrintManagementSystem_Сабитов.Layots
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Journal : Page
    {
        
        MainWindow mainWindow;
        public static Journal jou;
        public Journal(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            jou = this;
            Updateoperations();
        }
        public static void Updateoperations()
        {
            foreach (TypeOperationsWindow TOW in MainWindow.operations)
            {
                jou.Operations.Items.Add(TOW);
            }
        }
        private void AddOperation(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenLayot(MainWindow.pages.createOperations);
        }

        private void UpdateOperation(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveOperation(object sender, RoutedEventArgs e)
        {

        }
    }
}
