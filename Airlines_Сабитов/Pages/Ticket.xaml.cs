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
        public Ticket(MainWindow window, string from, string to, DateTime? start, DateTime? retur)
        {
            InitializeComponent();
            mainWindow = window;
            DateLoad(from, to, start, retur);
        }
        void DateLoad(string from, string to, DateTime? start, DateTime? retur)
        {
            foreach (Models.TicketClass ticket in mainWindow.ticketClasses)
            {
                bool valid = true;
                bool validRevers = false;
                if (!string.IsNullOrEmpty(from) && ticket.from != from)
                {
                    valid = false;
                }
                if (!string.IsNullOrEmpty(to) && ticket.to != to)
                {
                    valid = false;
                }
                if (start.HasValue) 
                {
                    if (ticket.time_start.Date != start.Value.Date)
                    {
                        valid = false;
                    }
                }
                if (retur.HasValue && !string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(from))
                {
                    if (ticket.from == "Екатеринбург")
                    {
                        validRevers = false;
                    }
                    if (ticket.time_start.Date == retur.Value.Date && ticket.from == to && ticket.to == from)
                    {
                        validRevers = true;
                    }
                }
                if(valid || validRevers)
                {
                    parrent.Children.Add(new Elements.Item(ticket));
                }
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Main(mainWindow));
        }
    }
}
