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
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Messages : UserControl
    {
        public bool edit = false;
        public Classes.MessagesContext ThisMessage;
        public Messages(Classes.MessagesContext message)
        {
            InitializeComponent();
            ThisMessage = message;
            Message.Text = message.Message;
            Date.Text = message.Create.ToString("dd.MM.yyyy");
        }
        private void DeleteMessage(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                edit = false;
                ThisMessage.Delete();
                MainWindow.mainWindow.parentMessage.Children.Remove(this);
            }
        }
        public static void ResetSelect()
        {
            foreach (Messages item in MainWindow.mainWindow.parentMessage.Children)
            {
                item.edit = false;
                item.Messag.Background = new SolidColorBrush(Colors.Black);
            }
        }
        private void Edit(object sender, MouseButtonEventArgs e)
        {
            MainWindow.editMessage = null;
            if (edit)
            {
                edit = false;
                Messag.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                ResetSelect();
                edit = true;
                MainWindow.editMessage = this;
                Messag.Background = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }
}
