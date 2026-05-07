using System.Windows;
using System.Windows.Controls;
using AppKeyPass.Context;
using AppKeyPass.Models;
using AppKeyPass.Pages;

namespace AppKeyPass.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private Storage _storage;
        private Main _currentMain;
        public Item(Storage storage, Main main)
        {
            InitializeComponent();
            _storage = storage;
            _currentMain = main;
            if(_storage != null)
            {
                tbLogin.Text = _storage.Login;
                tbName.Text = _storage.Name;    
                tbPassword.Text = _storage.Password;
                tbUrl.Text = _storage.Url;
            }
        }

        private void Update(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPages(new Pages.Add(_storage));
        }

        private void Delete(object sender, System.Windows.RoutedEventArgs e)
        {
            StorageContext.Delete(_storage.Id);
            _currentMain.sPStorageList.Children.Remove(this);
            MessageBox.Show("Данные удалены");
        }
    }
}
