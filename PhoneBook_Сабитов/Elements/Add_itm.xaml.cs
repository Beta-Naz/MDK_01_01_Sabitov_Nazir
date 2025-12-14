using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PhoneBook_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Add_itm.xaml
    /// </summary>
    public partial class Add_itm : UserControl
    {
        Page page_str;
        public Add_itm(Page _page_str)
        {
            InitializeComponent();
            page_str = _page_str;

            // создание анимации при инициализации
            DoubleAnimation oppgridAnimation = new DoubleAnimation();
            oppgridAnimation.From = 0;
            oppgridAnimation.To = 1;
            oppgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, oppgridAnimation);
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            // открытие окна с вводом новых данных
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, page_str);
        }
    }
}
