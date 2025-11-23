using FurnitureStore_Сабитов.Pages;
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
                image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/Image1.png"));
            }
            price.Content = item.price;
            name.Content = item.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalculateAll.totalPrice += int.Parse(price.Content.ToString()) * int.Parse(countTovar.Text);
            CalculateAll.totalCount += int.Parse(countTovar.Text);
            Pages.Main.init.cor.Content = $"Корзина ({CalculateAll.totalCount})";
            countTovar.Text = "0";
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            countTovar.Text = $"{int.Parse(countTovar.Text) + 1}";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(countTovar.Text) == 0)
            {
                return;
            }
            countTovar.Text = $"{int.Parse(countTovar.Text) - 1}";
        }
    }
}
