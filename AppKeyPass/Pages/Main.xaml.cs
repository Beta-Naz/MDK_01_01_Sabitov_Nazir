using System.Windows;
using System.Windows.Controls;
using AppKeyPass.Context;
using AppKeyPass.Models;

namespace AppKeyPass.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            GetStorage();
        }
        public async Task GetStorage()
        {
            List<Storage> storages = await StorageContext.Get();
            sPStorageList.Children.Clear();
            foreach(Storage storage in storages)
            {
                sPStorageList.Children.Add(new Elements.Item(storage,this));
            }
        }
        private void OpenPageAdd(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPages(new Pages.Add());
        }
    }
}
