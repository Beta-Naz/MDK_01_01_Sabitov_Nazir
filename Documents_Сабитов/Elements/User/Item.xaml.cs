using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Documents_Сабитов.Classes;

namespace Documents_Сабитов.Elements.User
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Classes.UserContext User;
        public Item(Classes.UserContext user)
        {
            InitializeComponent();
            User = user;
            lCode.Content = "Код: " + user.Id;
            string[] FIO = user.FIO.Trim().Split(' ');
            lFirstName.Content = FIO[0];
            lLastName.Content = FIO[1];
            lForename.Content = FIO[2];
        }

        private void EditDocument(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.UserPages.Add(User));
        }

        private void DeleteDocument(object sender, RoutedEventArgs e)
        {
            User.Delete();
            MainWindow.init.AllUsers = new UserContext().AllUser();
            MainWindow.init.frame.Navigate(new Pages.UserPages.Main());
        }
    }
}
