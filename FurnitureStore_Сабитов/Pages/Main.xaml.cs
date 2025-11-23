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

namespace FurnitureStore_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List<Classes.Item> allItems { get; set; }
        public Main()
        {
            InitializeComponent();
            allItems.Add(new Classes.Item("Шакаф", 20000, "kbgygj18c0u9jov_53541192.jpg"));
            LoadItems();
        }
        public void LoadItems()
        {
            parrent.Children.Clear();
            foreach (var item in allItems)
            {
                parrent.Children.Add(new Elements.Item(item));
            }
        }
    }
}
