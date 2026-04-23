using System.Windows;
using System.Windows.Controls;
using ChatStudents_Sabitov.Models;

namespace ChatStudents_Sabitov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? Instance { get; private set; }
        public User? LoginUser = null;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPages(new Pages.Login());
        }
        public void OpenPages(Page page)
        {
            frame.Navigate(page);
        }
    }
}