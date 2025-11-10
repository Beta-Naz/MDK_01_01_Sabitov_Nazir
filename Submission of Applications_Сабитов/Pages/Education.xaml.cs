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
    /// Логика взаимодействия для Education.xaml
    /// </summary>
    public partial class Education : Page
    {
        bool trr = false;
        bool tr;
        public Education()
        {
            InitializeComponent();
        }

        private void contuniePages(object sender, RoutedEventArgs e)
        {
            if((bool)class9.IsChecked || (bool)class11.IsChecked || (bool)sPO.IsChecked || (bool)vPO.IsChecked)
            {
                if((bool)atet.IsChecked || (bool)dip.IsChecked)
                {
                    seriaAndNomer_TextChanged(null, null);
                    if (tr)
                    {
                        sBall_TextChanged(null, null);
                        if (tr)
                        {
                            if (trr)
                            {
                                init.OpenPages(pages.status);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тип образовательного документа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите одну из баз", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show("Формат документов должен быть PNG, JPEG или PDF","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                trr = true;
                sourseImg.Text = openFileDialog.FileName;
            }
        }
        private void seriaAndNomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(seriaAndNomer.Text, "^\\d{10}$"))
            {
                tr = true;
                seriaAndNomer.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                seriaAndNomer.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void sBall_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(sBall.Text, "^[2-5]{1},[0-9]{2}$") || Match(sBall.Text, "^[2-5]{1}$"))
            {
                tr = true;
                sBall.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                sBall.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
