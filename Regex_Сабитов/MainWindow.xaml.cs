using Regex_Сабитов.Classes;
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

namespace Regex_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Passport> Passports = new List<Passport>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }
        public void LoadPassport()
        {
            lv_passport.Items.Clear();
            foreach (Passport Passport in Passports)
                lv_passport.Items.Add(Passport);
        }

        private void Add(object sender, RoutedEventArgs e) =>
            new Windows.Add(null).ShowDialog();

        private void Update(object sender, RoutedEventArgs e)
        {
            if(lv_passport.SelectedIndex >-1)
            {
                new Windows.Add(lv_passport.SelectedItems as Passport).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItems as Passport);
                LoadPassport();
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
