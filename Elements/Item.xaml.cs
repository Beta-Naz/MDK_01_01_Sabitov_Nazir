using Shop_Сабитов.Models;
using System.Windows.Controls;

namespace Shop_Сабитов.Elements
{
    public partial class Item : UserControl
    {
        public Item(object ItemData)
        {
            InitializeComponent();
            // Преобразование полученный объект в базовый класс
            Shop ShopData = ItemData as Shop;

            tb_Name.Content = ShopData.Name;
            tb_Price.Content = "Цена: " + ShopData.Price;
            if(ItemData is Children)
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
