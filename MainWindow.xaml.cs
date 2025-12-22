using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Shop_Сабитов.Classes;
using Shop_Сабитов.Models;

namespace Shop_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<object> AllItems = RepoItems.AllItems();
        public MainWindow()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI() 
        {
            parent.Children.Clear();
            foreach (object item in AllItems)
            {
                parent.Children.Add(new Elements.Item(item));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string search = Search.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(search))
                {
                    CreateUI();
                    return;
                }
                parent.Children.Clear();
                foreach (object item in AllItems)
                {
                    bool tr = false;
                    Shop ShopData = item as Shop;
                    if (ShopData.Name.Trim().ToLower().Contains(search) ||
                        $"{ShopData.Price}".Trim().ToLower().Contains(search))
                    {
                        tr = true;
                    }
                    if (ShopData is Children)
                    {
                        Children ChilDate = ShopData as Children;
                        if ($"{ChilDate.Age}".Trim().ToLower().Contains(search))
                        {
                            tr = true;
                        }
                    }
                    if (ShopData is Sport)
                    {
                        Sport SportDate = ShopData as Sport;
                        if ($"{SportDate.Size}".Trim().ToLower().Contains(search))
                        {
                            tr = true;
                        }
                    }
                    if (ShopData is Electronics)
                    {
                        Electronics ElectDate = ShopData as Electronics;
                        if ($"{ElectDate.BatteryCapacity}".Trim().ToLower().Contains(search) || 
                            $"{ElectDate.DrivingSpeed}".Trim().ToLower().Contains(search))
                        {
                            tr = true;
                        }
                    }
                    if(tr)
                    {
                        parent.Children.Add(new Elements.Item(item));
                    }
                }
            }
            catch 
            {
                CreateUI();
            }
        }
    }
}
