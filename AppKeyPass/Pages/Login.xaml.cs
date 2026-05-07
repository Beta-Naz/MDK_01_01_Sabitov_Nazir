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

namespace AppKeyPass.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        public async Task Auth(string login, string password)
        {
            string? token = await UserContext.Login(login, password);
            if(token == null)
            {
                MessageBox.Show("Логин или пароль указаны не верно");
            }
            else
            {
                MainWindow.Token = token;
                MainWindow.Instance.OpenPages(new Pages.Main());
            }
        }
        private void BtnAuth(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Необходимо указать логин пользователя");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Необходимо указать пароль пользователя");
                return;
            }
            Auth(tbLogin.Text, tbPassword.Text);   
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {

        }
    }
}
