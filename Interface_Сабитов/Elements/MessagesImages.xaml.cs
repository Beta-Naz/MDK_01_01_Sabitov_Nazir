using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для MessagesImages.xaml
    /// </summary>
    public partial class MessagesImages : UserControl
    {
        public Classes.MessagesContext ThisMessage;
        public MessagesImages(Classes.MessagesContext message)
        {
            ThisMessage = message;
            InitializeComponent();
            Date.Text = message.Create.ToString("dd.MM.yyyy");
            SendImages.ImageSource = new BitmapImage(new Uri(message.Message));
        }

        private void DeleteMessage(object sender, MouseButtonEventArgs e)
        {
            ThisMessage.Delete();
            MainWindow.mainWindow.parentMessage.Children.Remove(this);
        }
    }
}
