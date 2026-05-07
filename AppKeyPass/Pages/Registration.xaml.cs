using System.Windows;
using System.Windows.Controls;
using AppKeyPass.Context;
using AppKeyPass.Models;

namespace AppKeyPass.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
        public async Task Create(string login, string password)
        {
            User newUser = new User()
            {
                Login = login,
                Password = password,
            };
            bool token = await UserContext.Create(newUser);
            if (token)
            {
                MessageBox.Show("Регистрация пользователя прошла успешна");
                MainWindow.Instance.OpenPages(new Pages.Main());
            }
            else
            {
                MessageBox.Show("при регистрация пользователя прошла успешна");
            }
        }
        private void BtnCreate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Необходимо указать логин пользователя");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Password))
            {
                MessageBox.Show("Необходимо указать пароль пользователя");
                return;
            }
            Create(tbLogin.Text, tbPassword.Password);
        }
    }
}
