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
using static Submission_of_Applications_Сабитов.MainWindow;

namespace Submission_of_Applications_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Speciality.xaml
    /// </summary>
    public partial class Speciality : Page
    {
        public Speciality()
        {
            InitializeComponent();
        }

        private void contuniePages(object sender, RoutedEventArgs e)
        {
            if ((bool)x1.IsChecked || (bool)x2.IsChecked || (bool)x3.IsChecked || (bool)x4.IsChecked ||
                (bool)x5.IsChecked || (bool)x6.IsChecked || (bool)x7.IsChecked || (bool)x8.IsChecked ||
                (bool)x9.IsChecked || (bool)x10.IsChecked || (bool)x11.IsChecked || (bool)x12.IsChecked
                || (bool)x13.IsChecked)
            {
                if ((bool)first.IsChecked || (bool)noFirst.IsChecked)
                {
                    if ((bool)lich.IsChecked && (bool)dateOriginal.IsChecked)
                    {
                        init.OpenPages(pages.passport);
                    }
                    else
                    {
                        MessageBox.Show("Примите все соглашения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы впервые или не впервые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выбирите хотя бы одну професию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
