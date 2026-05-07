using System.Windows;
using System.Windows.Controls;
using AppKeyPass.Context;
using AppKeyPass.Models;

namespace AppKeyPass.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Storage _changeStorage;
        public Add(Storage storage = null)
        {
            InitializeComponent();
            _changeStorage = storage;
            if(_changeStorage != null)
            {
                tbName.Text = _changeStorage.Name;
                tbPassword.Text = _changeStorage.Password;
                tbLogin.Text = _changeStorage.Login;
                tbUrl.Text = _changeStorage.Url;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text) 
                || string.IsNullOrEmpty(tbPassword.Text) 
                || string.IsNullOrEmpty(tbLogin.Text) 
                || string.IsNullOrEmpty(tbUrl.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if(_changeStorage == null)
            {
                Storage newStorage = new()
                {
                    Name = tbName.Text,
                    Password = tbPassword.Text,
                    Login = tbLogin.Text,
                    Url = tbUrl.Text,
                };
                StorageContext.Add(newStorage);
            }
            else
            {
                _changeStorage.Name = tbName.Text;
                _changeStorage.Password = tbPassword.Text;
                _changeStorage.Url = tbUrl.Text;
                _changeStorage.Login = tbLogin.Text;
                StorageContext.Update(_changeStorage);
            }
            MessageBox.Show("Данные сохранены");
            MainWindow.Instance.OpenPages(new Pages.Main());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
    }
}
