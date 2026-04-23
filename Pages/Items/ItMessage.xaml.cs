using System.Windows.Controls;
using ChatStudents_Sabitov.Classes.Common;
using ChatStudents_Sabitov.Models;

namespace ChatStudents_Sabitov.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для ItMessage.xaml
    /// </summary>
    public partial class ItMessage : UserControl
    {
        public ItMessage(Message message, User UserFrom)
        {
            InitializeComponent();
            if(UserFrom == null)
            {
                return;
            }
            if (UserFrom.Photo != null)
            {
                imgUser.Source = BitmapFromArrayByte.LoadImage(UserFrom.Photo);
            }
            FIO.Content = UserFrom?.ToFIO();
            tbMessage.Text = message.ContentMessage;

        }
    }
}
