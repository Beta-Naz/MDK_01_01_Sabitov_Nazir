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

namespace Shop_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(object ItemData)
        {
            InitializeComponent();
            // Преобразование полученный объект в базовый класс
            Classes.Shop ShopData = ItemData as Classes.Shop;

            tb_Name.Content = ShopData.Name;
            tb_Price.Content = "Цена: " + ShopData.Price;

            if(ItemData is Classes.Children)
            {
                Classes.Children ChilDate = ItemData as Classes.Children;
                tb_Characteristic.Content = "Возраст: " + ChilDate.Age;
            }
            if(ItemData is Classes.Sport)
            {
                Classes.Sport SporDate = ItemData as Classes.Sport;
                tb_Characteristic.Content = "Размер: " + SporDate.Size;
            }
        }
    }
}
