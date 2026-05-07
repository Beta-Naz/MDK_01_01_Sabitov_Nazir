using System.Windows.Controls;
using ChatStudents_Sabitov.Classes.Common;
using ChatStudents_Sabitov.Models;

namespace ChatStudents_Sabitov.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class ItUser : UserControl
    {
        private User _currentUser;
        private Main _currentMain;
        public ItUser(User user, Main main, string lastMessage = "")
        {
            InitializeComponent();
            _currentUser = user;
            _currentMain = main;
            if(_currentUser.Photo != null)
            {
                imgUser.Source = BitmapFromArrayByte.LoadImage(_currentUser.Photo);
            }
            
            FIO.Content = user.ToFIO();
            imageOnline.Visibility = DateTime.Now - user.LastLogin < 
                TimeSpan.FromMinutes(5) ? System.Windows.Visibility.Visible : 
                System.Windows.Visibility.Collapsed;
            if (!string.IsNullOrEmpty(lastMessage))
            {
                if(lastMessage.Length < 20)
                {
                    LastMessage.Content = lastMessage;
                }
                else
                {
                    LastMessage.Content = lastMessage[..20] + "...";
                }
            }
        }

        private void SelectChat(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentMain.SelectUser = _currentUser;
            _currentMain.SelectItUser = this;
        }
        public void UpdateLastMessage(string lastMessage)
        {
            if (lastMessage.Length < 20)
            {
                LastMessage.Content = lastMessage;
            }
            else
            {
                LastMessage.Content = lastMessage[..20] + "...";
            }
        }
    }
}
