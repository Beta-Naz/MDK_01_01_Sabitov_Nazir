using Human_Сабитов.Classes;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Human_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Classes.Human Human;
        public Item(object Data)
        {
            InitializeComponent();
            Human = Data as Classes.Human;
            img.Source = new BitmapImage(new Uri(this.Human.Img));
            name.Content = Human.Name;
            lrace.Content = Data.GetType().Name; 
        }

        public void Speak(object sender, MouseButtonEventArgs e)
        {
            Human.Speak(text);
        }
    }
}
