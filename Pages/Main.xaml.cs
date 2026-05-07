using System.Windows.Controls;
using System.Windows.Threading;
using ChatStudents_Sabitov.Classes;
using ChatStudents_Sabitov.Classes.Common;
using ChatStudents_Sabitov.Models;
using Microsoft.Windows.Themes;
using System.Windows.Input;
using ChatStudents_Sabitov.Pages.Items;

namespace ChatStudents_Sabitov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        private User? _selectUser = null;
        public User? SelectUser
        {
            get
            {
                return _selectUser;
            }
            set
            {
                _selectUser = value;
                UpdateSelectUser();
            }
        }
        public ItUser SelectItUser;
        public UsersContext UsersContext = new();
        public MessagesContext MessagesContext = new();
        public DispatcherTimer Timer = new() { Interval =new System.TimeSpan(0,0,3) };
        public Main()
        {
            InitializeComponent();
            LoadUsers();
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }
        public void LoadUsers()
        {
            if (MainWindow.Instance == null || MainWindow.Instance.LoginUser == null)
            {
                return;
            }
            ParentUsers.Children.Clear();
            foreach (var user in UsersContext.Users)
            {
                if(user.Id != MainWindow.Instance.LoginUser.Id)
                {
                    Message? message = null;
                    if (MessagesContext.Messages != null && MessagesContext.Messages.ToList().Count != 0)
                    {
                        message = MessagesContext.Messages.Where(x =>
                        (x.UserFrom == MainWindow.Instance.LoginUser.Id &&
                        x.UserTo == user.Id) ||
                        (x.UserTo == MainWindow.Instance.LoginUser.Id &&
                        x.UserFrom == user.Id)).OrderByDescending(x => x.TimeSending).First();
                    }
                    ItUser itUser;
                    if (message != null)
                    {
                        itUser = new Items.ItUser(user, this, message.ContentMessage);
                    }
                    else
                    {
                        itUser = new Items.ItUser(user, this);
                    }
                    ParentUsers.Children.Add(itUser);
                }
            }
        }
        public void IsOnlineUser()
        {
            foreach (var user in UsersContext.Users)
            {
                if (user.Id != MainWindow.Instance?.LoginUser?.Id)
                {
                    if(DateTime.Now - user.LastLogin > TimeSpan.FromMinutes(5))
                    {
                        LoadUsers();
                        break;
                    }
                }
            }
        }
        public void LoadMessages()
        {
            if(MainWindow.Instance == null || MainWindow.Instance.LoginUser == null || SelectUser == null)
            {
                return;
            }
            ParentMessages.Children.Clear();
            List<Message> messages = 
                MessagesContext.Messages.Where(x => 
                (x.UserFrom == MainWindow.Instance.LoginUser.Id &&
                x.UserTo == SelectUser.Id) ||
                (x.UserTo == MainWindow.Instance.LoginUser.Id &&
                x.UserFrom == SelectUser.Id)).OrderBy(x => x.TimeSending).ToList();
            foreach (var message in messages)
            {
                ParentMessages.Children.Add(new Items.ItMessage(message, UsersContext.Users.Where(x => x.Id == message.UserFrom).First()));
                if(SelectItUser != null)
                {
                    SelectItUser.UpdateLastMessage(message.ContentMessage);
                }
            }
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            UpdateSelectUser();
            if (MainWindow.Instance != null && MainWindow.Instance.LoginUser != null)
            {
                UsersContext.Users.Where(x => x.Firstname == MainWindow.Instance.LoginUser.Firstname &&
                                   x.Lastname == MainWindow.Instance.LoginUser.Lastname &&
                                   x.Surname == MainWindow.Instance.LoginUser.Surname).First().LastLogin = DateTime.Now;
                UsersContext.SaveChanges();
                IsOnlineUser();
            }
        }
        public void UpdateSelectUser()
        {
            if(SelectUser == null)
            {
                Chat.Visibility = System.Windows.Visibility.Collapsed;
                return;
            }
            Chat.Visibility = System.Windows.Visibility.Visible;
            if (SelectUser.Photo != null) imgUser.Source = BitmapFromArrayByte.LoadImage(SelectUser.Photo);
            FIO.Content = SelectUser.ToFIO();
            LoadMessages();
        }

        private void Send(object sender, KeyEventArgs e)
        {
            if (MainWindow.Instance == null || MainWindow.Instance.LoginUser == null || SelectUser == null)
            {
                return;
            }
            if (e.Key == Key.Enter)
            {
                Message message = new Message(
                    MainWindow.Instance.LoginUser.Id,
                    SelectUser.Id,
                    Message.Text);
                MessagesContext.Messages.Add(message);
                MessagesContext.SaveChanges();
                ParentMessages.Children.Add(new Pages.Items.ItMessage(message, MainWindow.Instance.LoginUser));
                Message.Text = "";
            }
        }
    }
}
