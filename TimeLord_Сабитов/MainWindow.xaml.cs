using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLord_Сабитов
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPages(pages.stopwatch);
        }
        public enum pages
        {
            stopwatch
        }
        public void OpenPages(pages _page)
        {
            if(_page == pages.stopwatch)
            {
                frame.Navigate(new Pages.Stopwatch());
            }
        }
    }
}