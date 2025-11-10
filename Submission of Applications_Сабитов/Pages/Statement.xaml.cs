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
    /// Логика взаимодействия для Statement.xaml
    /// </summary>
    public partial class Statement : Page
    {
        bool tr;
        public Statement()
        {
            InitializeComponent();
        }
        private void contuniePages(object sender, RoutedEventArgs e)
        {
            theEnds_TextChanged(null,null);
            if (tr)
            {
                theEnds_TextChanged(null, null);
                if (tr)
                {
                    if((bool)och.IsChecked || (bool)notOch.IsChecked)
                    {
                        if((bool)many.IsChecked || (bool)noMany.IsChecked)
                        {
                            init.OpenPages(pages.education);
                        }
                        else
                        {
                            MessageBox.Show("Вы забыли отметить тип оплаты обучения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы забыли отметить тип обучения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void theEnds_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(theEnds.Text, "^[а-яА-Я0-9\\s,.ёЁ],[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                theEnds.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
               theEnds.Background = new SolidColorBrush(Colors.Red);
            }
        }
        private void dateTheEnds_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(dateTheEnds.Text, "^[0-3]{1}[0-9]{1}.[01]{1}[0-9]{1}.\\d{4}$"))
            {
                tr = true;
                dateTheEnds.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                dateTheEnds.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
