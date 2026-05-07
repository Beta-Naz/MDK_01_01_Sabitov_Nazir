using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public static string Token;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPages(new Pages.Login());
        }
        public void OpenPages(Page openPage)
        {
            frame.Navigate(openPage);
        }
    }
}