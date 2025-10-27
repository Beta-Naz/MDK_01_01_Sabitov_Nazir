using Interface_Сабитов.Classes;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;


namespace Interface_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Elements.Messages editMessage;
        public UsersContext usersContext = new UsersContext();
        public MessagesContext messagesContext = new MessagesContext();
        public int IdSelectUser = -1;
        public static MainWindow mainWindow;
        public MainWindow()
        { 
            InitializeComponent();
            mainWindow = this;
            LoadUsers();
        }
        public void LoadUsers()
        {
            foreach (Models.Users User in usersContext.AllUsers)
            {
                ParentUser.Children.Add(new Elements.Users(User));
            }
        }
        public void SelectUser(Models.Users User)
        {
            if(User != null)
            {
                IdSelectUser = usersContext.AllUsers.FindIndex(x => x == User);
                Elements.Messages.ResetSelect();
            }
            parentMessage.Children.Clear();
            foreach (MessagesContext messages in MessagesContext.AllMessages.FindAll(x => x.IdUsers == IdSelectUser))
            {
                int index = messages.Message.LastIndexOf(".");
                if (index != -1)
                {
                    string extensionImage = messages.Message.Substring(index).ToLower();
                    string[] validExtension = { ".png", ".jpg", ".jpeg" };
                    if (validExtension.Contains(extensionImage))
                    {
                        parentMessage.Children.Add(new Elements.MessagesImages(messages));
                        continue;
                    }
                }
                parentMessage.Children.Add(new Elements.Messages(messages));
            }
            BlockMessage.IsEnabled = true;
        }

        private void SendMessages(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(editMessage != null)
                {    
                    if (editMessage.edit)
                    {
                        editMessage.ThisMessage.Edit(Message.Text);
                        editMessage.Messag.Background = new SolidColorBrush(Colors.Black);
                        editMessage.edit = false;
                        Message.Text = "";
                        SelectUser(null);
                        return;
                    }
                }
                if (IdSelectUser == -1)
                {
                    return;
                }
                if (Message.Text.ToLower().Contains("удовлетворительно") || Message.Text.ToLower().Contains("3"))
                {
                    Message.Text = "pack://application:,,,/Interface_Сабитов;component/Images/___.png";
                }
                else if (Message.Text.ToLower().Contains("хорошо"))
                {
                    Message.Text = "pack://application:,,,/Interface_Сабитов;component/Images/NoRep.png";
                }
                else if (Message.Text.ToLower().Contains("отлично"))
                {
                    Message.Text = "pack://application:,,,/Interface_Сабитов;component/Images/Rep.png";
                }
                MessagesContext newMessages = new MessagesContext(Message.Text, DateTime.Now, IdSelectUser);
                newMessages.Save();
                Message.Text = "";
                SelectUser(null);
            }
        }


        private void DragEnter_img(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void Drop_img(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string [] Image = (string [])e.Data.GetData(DataFormats.FileDrop);
                string sourseImage = Image[0];
                string extensionImage = sourseImage.Substring(sourseImage.LastIndexOf(".")).ToLower();
                string[] validExtension = {".png",".jpg",".jpeg"};
                if (validExtension.Contains(extensionImage))
                {
                    MessagesContext newMessages = new MessagesContext(sourseImage, DateTime.Now, IdSelectUser);
                    newMessages.Save();
                    SelectUser(null);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, перетащите файл изображения .png, .jpg, .jpeg");
                }
            }
        }
        private void PreviewDragOver_img(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
