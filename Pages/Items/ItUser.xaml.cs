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
        public ItUser(User user, Main main)
        {
            InitializeComponent();
            _currentUser = user;
            _currentMain = main;
            if(_currentUser.Photo != null)
            {
                imgUser.Source = BitmapFromArrayByte.LoadImage(_currentUser.Photo);
            }
            FIO.Content = user.ToFIO();
        }

        private void SelectChat(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentMain.SelectUser = _currentUser;
        }
    }
}
