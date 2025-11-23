using FurnitureStore_Сабитов.Classes;
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
    /// Логика взаимодействия для Categor.xaml
    /// </summary>
    public partial class Categor : Page
    {
        public static Categor init;
        public List<Classes.CategorItems> allCategorItems = new List<Classes.CategorItems>();
        public Categor()
        {
            InitializeComponent();
            init = this;
            allCategorItems.Add(new Classes.CategorItems("Мебель для сидения", "CategorImage1.png", "seatingFurniture"));
            allCategorItems.Add(new Classes.CategorItems("Мебель для хранения", "CategorImage2.png", "storageFurniture"));
            LoadItems();
        }
        public void LoadItems()
        {
            parrent.Children.Clear();
            foreach (var item in allCategorItems)
            {
                parrent.Children.Add(new Elements.CategorItem(item));
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

}
