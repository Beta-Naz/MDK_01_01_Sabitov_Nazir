using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Documents_Сабитов.Classes;
using Documents_Сабитов.Model;
using Microsoft.Win32;

namespace Documents_Сабитов.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Model.User User;
        public Add(UserContext user = null)
        {
            InitializeComponent();
            User = user;
            if(User == null)
            {
                return;
            }
            string[] FIO = user.FIO.Trim().Split(' ');
            tbFirstName.Text = FIO[0];
            tbLastName.Text = FIO[1];
            tbForename.Text = FIO[2];

        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.mainUser);
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbFirstName.Text))
            {
                MessageBox.Show("Напишите фамилию");
                return;
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                MessageBox.Show("Напишите имя");
                return;
            }
            if (string.IsNullOrEmpty(tbForename.Text))
            {
                tbForename.Text = "";
            }
            var fio = new[]
            {
                tbFirstName.Text,
                tbLastName.Text,
                tbForename.Text
            };
            string FIO = "";
            for(int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(fio[i]))
                {
                    fio[i] = "";
                }
                FIO += fio[i];
                if (i < 2)
                {
                    FIO += " ";
                }
            }
            Classes.UserContext newUser = new Classes.UserContext()
            {
                FIO = FIO,
            };
            if (User == null)
            {
                newUser.Save();
                MessageBox.Show("Документ добавлен");
            }
            else
            {
                newUser.Save(true);
                MessageBox.Show("Документ изменен");
            }
        }
    }
}
