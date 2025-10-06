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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<object> AllItems = Classes.RepoItems.AllItems();
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
                    Classes.Shop ShopData = item as Classes.Shop;
                    if (ShopData.Name.Trim().ToLower().Contains(search) ||
                        $"{ShopData.Price}".Trim().ToLower().Contains(search))
                    {
                        tr = true;
                    }
                    if (ShopData is Classes.Children)
                    {
                        Classes.Children ChilDate = ShopData as Classes.Children;
                        if ($"{ChilDate.Age}".Trim().ToLower().Contains(search))
                        {
                            tr = true;
                        }
                    }
                    if (ShopData is Classes.Sport)
                    {
                        Classes.Sport SportDate = ShopData as Classes.Sport;
                        if ($"{SportDate.Size}".Trim().ToLower().Contains(search))
                        {
                            tr = true;
                        }
                    }
                    if (ShopData is Classes.Electronics)
                    {
                        Classes.Electronics ElectDate = ShopData as Classes.Electronics;
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
