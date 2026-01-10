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

namespace Airlines_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(Models.TicketClass ticket)
        {
            InitializeComponent(); 
            price.Content = ticket.price.ToString() + " P";
            startDate.Content = ticket.time_start.ToString("dd.MMMM.yyyy");
            startTime.Content = ticket.time_start.ToString("t");
            endDate.Content = ticket.time_way.ToString("dd.MMMM.yyyy"); ;
            endTime.Content = ticket.time_way.ToString("t");
            TimeSpan duration = ticket.time_way - ticket.time_start;
            timer.Content = $"В пути {(int)duration.TotalHours}ч {duration.Minutes}мин";
            city.Content = ticket.from.ToString();
            endCity.Content = ticket.to.ToString();
        }
    }
}
