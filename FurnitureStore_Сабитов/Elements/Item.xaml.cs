using System;
using System.Collections.Generic;
using System.IO;
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

namespace FurnitureStore_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(Classes.Item item)
        {
            InitializeComponent();

            if(item == null)
            {
                return;
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src))
            {
                image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src));
            }
            else
            {
                image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/placeholder.png"));
            }
            price.Content = item.price;
            name.Content = item.name;
        }
    }
}
