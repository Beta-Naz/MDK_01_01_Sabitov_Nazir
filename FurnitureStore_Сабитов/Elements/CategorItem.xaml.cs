using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для CategorItem.xaml
    /// </summary>
    public partial class CategorItem : UserControl
    {
        string Type;
        public CategorItem(Classes.CategorItems item)
        {
            InitializeComponent();

            if (item == null)
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
            name.Content = item.Name;
            Type = item.Type;
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main, Type);
        }
    }
}
