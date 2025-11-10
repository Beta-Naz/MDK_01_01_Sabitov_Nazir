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
using Microsoft.Win32;
using static Submission_of_Applications_Сабитов.MainWindow;

namespace Submission_of_Applications_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Status.xaml
    /// </summary>
    public partial class Status : Page
    {
        bool trr = false;
        public Status()
        {
            InitializeComponent();
        }
        private void contuniePages(object sender, RoutedEventArgs e)
        {
            if((bool)imeu.IsChecked ||  (bool)noImeu.IsChecked)
            {
                if(trr)
                {
                    init.OpenPages(pages.speciality);
                }
            }
            else
            {
                MessageBox.Show("Имеете ли вы военный билет, отметьте пожалуйста", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenImg(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "images (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string type = openFileDialog.SafeFileName.Split('.')[1];
                if (type != "png" && type != "jpeg" && type != "pdf")
                {
                    MessageBox.Show("Формат документов должен быть PNG, JPEG или PDF", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                trr = true;
                sourseImage.Text = openFileDialog.FileName;
            }
        }
    }
}
