using System.Windows;
using System.Windows.Controls;
using ChatStudents_Sabitov.Classes;
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
        private void Window_Closed(object sender, EventArgs e)
        {
            if (LoginUser != null)
            {
                UsersContext usersContext = new UsersContext();
                usersContext.Users.Where(x => x.Firstname == LoginUser.Firstname &&
                                   x.Lastname == LoginUser.Lastname &&
                                   x.Surname == LoginUser.Surname).First().LastLogin = DateTime.Now;
                usersContext.SaveChanges();
            }
        }
    }
}