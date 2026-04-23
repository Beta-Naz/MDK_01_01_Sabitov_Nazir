using System.Windows.Controls;
using System.Windows.Threading;
using ChatStudents_Sabitov.Classes;
using ChatStudents_Sabitov.Models;
using Microsoft.Windows.Themes;

namespace ChatStudents_Sabitov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public User? SelectUser = null;
        public UsersContext UsersContext = new();
        public MessagesContext MessagesContext = new();
        public DispatcherTimer Timer = new() { Interval =new System.TimeSpan(0,0,3) };
        public Main()
        {
            InitializeComponent();
        }
        public void LoadUser()
        {
            ParentUsers.Children.Clear();
            foreach (var user in UsersContext.Users)
            {
                if(user.Id != MainWindow.Instance?.LoginUser?.Id)
                {
                    ParentUsers.Children.Add(new Items.ItUser(user, this));
                }
            }
        }
    }
}
