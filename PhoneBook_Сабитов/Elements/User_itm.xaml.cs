using ClassModule;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PhoneBook_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для User_itm.xaml
    /// </summary>
    public partial class User_itm : UserControl
    {
        User user_loc;
        public User_itm(User _user)
        {
            InitializeComponent();
            user_loc = _user;
            if (_user.fio_user != null)
            {
                name_user.Content = _user.fio_user;
                phone_user.Content = "Номер: " + _user.phone_num;
            }

            // создание анимации при инициализации
            DoubleAnimation oppgridAnimation = new DoubleAnimation();
            oppgridAnimation.From = 0;
            oppgridAnimation.To = 1;
            oppgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, oppgridAnimation);
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.User_win(user_loc));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);
                Call userFind = MainWindow.connect.calls.Find(x => x.user_id == user_loc.id);

                if (userFind != null)
                {
                    var click = MessageBox.Show("У данного клиента есть звонки, все равно удалить его?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (click == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                string vs1 = $"DELETE FROM [calls] WHERE [user_id] = '{user_loc.id.ToString()}'";
                var pc1 = MainWindow.connect.QueryAccess(vs1);
                string vs = $"DELETE FROM [users] WHERE [Код] = " + user_loc.id.ToString() + "";
                var pc = MainWindow.connect.QueryAccess(vs);
                    MessageBox.Show("Успешное удаление клиента", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);
                    MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.users);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Click_show_calls(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, null, Pages.Main.page_main.calls, user_loc.id);
        }
    }
}
