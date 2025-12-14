using ClassModule;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace PhoneBook_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Call_itm.xaml
    /// </summary>
    public partial class Call_itm : UserControl
    {
        Call call_loc;
        public Call_itm(Call _call)
        {
            InitializeComponent();
            call_loc = _call;
            if (_call != null && !string.IsNullOrEmpty(_call.time_start) && !string.IsNullOrEmpty(_call.time_end))
            {
                try
                {
                    User user_loc = MainWindow.connect.users.Find(x => x.id == _call.user_id);
                    category_call_text.Content = user_loc.fio_user;
                    string[] dateLoc1 = _call.time_start.Split(' ');
                    string[] date1 = dateLoc1[0].Split('.');
                    string[] dateLoc2 = _call.time_end.Split(' ');
                    string[] date2 = dateLoc2[0].Split('.');

                    DateTime dateStart = new DateTime(int.Parse(date1[2]),
                        int.Parse(date1[1]),
                        int.Parse(date1[0]),
                        int.Parse(dateLoc1[1].Split(':')[0]),
                        int.Parse(dateLoc1[1].Split(':')[1]), 0);
                    DateTime dateFinish = new DateTime(int.Parse(date2[2]),
                        int.Parse(date2[1]),
                        int.Parse(date2[0]),
                        int.Parse(dateLoc2[1].Split(':')[0]),
                        int.Parse(dateLoc2[1].Split(':')[1]), 0);
                    TimeSpan dateEnd = dateFinish.Subtract(dateStart);
                    time_call_text.Content = "Продолжительность звонка: " + dateEnd.ToString();
                    number_call_text.Content = "Номер телефона: " + user_loc.phone_num;

                    img_category_call.Source = (_call.category_call == 1) ?
                        new BitmapImage(new Uri(@"img/out.png", UriKind.RelativeOrAbsolute)) : new BitmapImage(new Uri(@"img/in.png", UriKind.RelativeOrAbsolute));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке звонка: {ex.Message}");
                }
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
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.Call_win(call_loc));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                string vs = $"DELETE FROM [calls] WHERE [Код] = " + call_loc.id.ToString() + "";
                var pc = MainWindow.connect.QueryAccess(vs);
                MessageBox.Show("Успешное удаление звонка", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.calls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
