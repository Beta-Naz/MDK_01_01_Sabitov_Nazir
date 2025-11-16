using System.Windows;

namespace Pizza_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string localPath;
        public MainWindow()
        {
            InitializeComponent();
            localPath = System.IO.Directory.GetCurrentDirectory();

            OpenPahes(pages.main);
        }
        public enum pages
        {
            main
        }
        public void OpenPahes(pages _pages)
        {
            if(_pages == pages.main)
            {
                frame.Navigate(new Layouts.Main(this));
            }
        }
    }
}
