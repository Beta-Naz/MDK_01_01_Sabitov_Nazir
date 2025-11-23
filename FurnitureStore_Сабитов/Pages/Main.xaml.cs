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
        public static Main init;
        public List<Classes.Item> allItems = new List<Classes.Item>();
        public Main(string type)
        {
            InitializeComponent();
            init = this;
            allItems.Add(new Classes.Item("Шакаф", 20000, "kbgygj18c0u9jov_53541192.jpg", new List<string> { "storageFurniture" }));
            allItems.Add(new Classes.Item("Кресло из чистого золота", 999, "Image1.png", new List<string> { "seatingFurniture" }));
            allItems.Add(new Classes.Item("Мраморный табурет", 1000, "Image2.png", new List<string> { "seatingFurniture" }));
            allItems.Add(new Classes.Item("Тумбочка", 99999, "Image3.png", new List<string> { "storageFurniture" }));
            allItems.Add(new Classes.Item("Кресло из алмазов", 10, "Image4.png", new List<string> { "seatingFurniture" }));
            allItems.Add(new Classes.Item("Костяной стул", 9999999, "Image5.png", new List<string> { "seatingFurniture" }));
            LoadItems(type);
        }
        public void LoadItems(string type)
        {
            parrent.Children.Clear();
            foreach (var item in allItems)
            {
                if(type == "All")
                {
                    parrent.Children.Add(new Elements.Item(item));
                }
                else if(item.type.Contains(type))
                {
                    parrent.Children.Add(new Elements.Item(item));
                }
            }
        }
        private void cor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Сумма всех товаров = {CalculateAll.totalPrice}");
        }

        private void categor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.categor, "All");
        }
    }
    public class CalculateAll
    {
        public static int totalPrice { get; set; } = 0;
        public static int totalCount { get; set; } = 0;
    }
}
