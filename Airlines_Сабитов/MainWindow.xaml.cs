using Airlines_Сабитов.Models;
using System.Collections.Generic;
using System.Windows;

namespace Airlines_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TicketClass> ticketClasses = new List<TicketClass>();
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Pages.Main(this));
        }
    }
}
