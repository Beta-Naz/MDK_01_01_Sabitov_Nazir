using Shop_Сабитов.Models;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Shop_Сабитов.Elements
{
    public partial class Item : UserControl
    {
        public Item(object ItemData)
        {
            InitializeComponent();
            // Преобразование полученный объект в базовый класс
            Shop ShopData = ItemData as Shop;
            src.Source = new BitmapImage(new Uri(ShopData.Src, UriKind.Relative));
            tb_Name.Content = ShopData.Name;
            tb_Price.Content = ShopData.Price - (ShopData.Price / 100 * ShopData.Discount);
            tb_Discount.Content = ShopData.Discount;
            if (ItemData is Children)
            {
                Children ChilDate = ItemData as Children;
                tb_Characteristic.Content = "Возраст: " + ChilDate.Age;
            }
            if(ItemData is Sport)
            {
                Sport SporDate = ItemData as Sport;
                tb_Characteristic.Content = "Размер: " + SporDate.Size;
            }
            if (ItemData is Electronics)
            {
                Electronics ElectDate = ItemData as Electronics;
                tb_Characteristic.Content = "Ёмкость аккумулятора: " + 
                    ElectDate.BatteryCapacity + " (Ач)" + "\n" + "Саморазряд : " + ElectDate.DrivingSpeed + "% в год";
            }
        }
    }
}
