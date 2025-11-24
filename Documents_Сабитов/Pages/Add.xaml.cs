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
using Documents_Сабитов.Classes;
using Microsoft.Win32;

namespace Documents_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        string s_src = "";
        public Add(DocumentContext document = null)
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "PNG (*.png)|*.png|All files(*.*)|*.*";
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != "")
            {
                src.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                s_src = openFileDialog.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if(s_src.Length == 0)
            {
                MessageBox.Show("Необходимо выберать изображение");
                return;
            }
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (tbUser.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать ответственного");
                return;
            }
            if (tbDocumentCode.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать код документа");
                return;
            }
            if (tbDate.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать дату поступления");
                return;
            }
            if (tbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать указать статус документа");
                return;
            }
            if (tbDirection.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать направление");
                return;
            }
        }
    }
}
