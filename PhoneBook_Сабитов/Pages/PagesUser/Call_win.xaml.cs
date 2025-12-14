using System;
using System.Windows;
using System.Windows.Controls;
using ClassModule;

namespace PhoneBook_Сабитов.Pages.PagesUser
{
    /// <summary>
    /// Логика взаимодействия для Call_win.xaml
    /// </summary>
    public partial class Call_win : Page
    {
        Call call_itm;
        public Call_win(Call _call)
        {
            InitializeComponent();
            call_itm = _call;

            if (_call.time_start != null)
            {
                string[] datetimeStart = _call.time_start.Split(' ');
                string[] dateStart = datetimeStart[0].Split('.');
                date_start_call.SelectedDate = new DateTime(int.Parse(dateStart[2]), int.Parse(dateStart[1]), int.Parse(dateStart[0]));
                time_start.Text = datetimeStart[1];

                string[] datetimeFinish = _call.time_end.Split(' ');
                string[] dateFinish = datetimeFinish[0].Split('.');
                date_end_call.SelectedDate = new DateTime(int.Parse(dateFinish[2]), int.Parse(dateFinish[1]), int.Parse(dateFinish[0]));
                time_finish.Text = datetimeFinish[1];
            }
            else
            {
                time_start.Text = "00:00";
                time_finish.Text = "00:00";
            }

            ComboBoxItem combItm = new ComboBoxItem();
            combItm.Tag = 1;
            combItm.Content = "Исходящий";
            if (_call.category_call == 1) combItm.IsSelected = true;
            call_category_text.Items.Add(combItm);

            ComboBoxItem combItm1 = new ComboBoxItem();
            combItm1.Tag = 2;
            combItm1.Content = "Входящий";
            if (_call.category_call == 2) combItm1.IsSelected = true;
            call_category_text.Items.Add(combItm1);

            MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);
            foreach (User itm in MainWindow.connect.users)
            {
                ComboBoxItem combUser = new ComboBoxItem();
                combUser.Tag = itm.id;
                combUser.Content = itm.fio_user;
                if (_call.user_id == itm.id) combUser.IsSelected = true;
                user_select.Items.Add(combUser);
            }
        }

        private void Click_Call_Redact(object sender, RoutedEventArgs e)
        {
            if (!CheckTime(time_start.Text))
            {
                MessageBox.Show("Время старта не правильно");
                return;
            }
            if (!CheckTime(time_finish.Text))
            {
                MessageBox.Show("Время конца не правильно");
                return;
            }

            if (date_start_call.SelectedDate != null && date_end_call.SelectedDate != null)
            {
                DateTime dateStart = date_start_call.SelectedDate.Value;
                DateTime dateFinish = date_end_call.SelectedDate.Value;

                // Добавляем время к датам
                if (CheckTime(time_start.Text) && CheckTime(time_finish.Text))
                {
                    TimeSpan startTime = TimeSpan.Parse(time_start.Text);
                    TimeSpan endTime = TimeSpan.Parse(time_finish.Text);

                    dateStart = dateStart.Date + startTime;
                    dateFinish = dateFinish.Date + endTime;
                }
                if (dateStart <= dateFinish)
                {
                    User id_temp_user;
                    if (user_select.SelectedItem != null)
                        id_temp_user = MainWindow.connect.users.Find(x => x.id == Convert.ToInt32(((ComboBoxItem)user_select.SelectedItem).Tag));
                    else
                    {
                        MessageBox.Show("Запрос не был обработан. Вы не указали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int id_calls_categ;
                    if (call_category_text.SelectedItem != null)
                        id_calls_categ = Convert.ToInt32(((ComboBoxItem)call_category_text.SelectedItem).Tag);
                    else
                    {
                        MessageBox.Show("Запрос не был обработан. Вы не указали категорию звонка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (call_itm.time_end == null)
                    {
                        int id = MainWindow.connect.SetLastId(ClassConnection.Connection.tabels.calls);

                        string query = $"INSERT INTO [calls] ([Код], [user_id], [category_call], [date_call], [time_start], [time_end]) VALUES ({id.ToString()}, " +
                        $"{id_temp_user.id.ToString()}, {id_calls_categ.ToString()}, '{dateStart.ToString().Split(' ')[0]}', " +
                        $"'{date_start_call.SelectedDate.Value.ToString().Split(' ')[0]} {time_start.Text}', " +
                        $"'{date_end_call.SelectedDate.Value.ToString().Split(' ')[0]} {time_finish.Text}')";
                        MainWindow.connect.QueryAccess(query);
                        MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                        MessageBox.Show("Успешное добавление звонка", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.calls);
                    }
                    else
                    {
                        string query = $"UPDATE [calls] SET [user_id] = '{id_temp_user.id.ToString()}', " +
                        $"[category_call]='{id_calls_categ.ToString()}', " +
                        $"[date_call]='{date_start_call.SelectedDate.Value.ToString().Split(' ')[0]}', " +
                        $"[time_start]='{date_start_call.SelectedDate.Value.ToString().Split(' ')[0]} {time_start.Text}', " +
                        $"[time_end]='{date_end_call.SelectedDate.Value.ToString().Split(' ')[0]} {time_finish.Text}' WHERE Код = {call_itm.id}";
                        MainWindow.connect.QueryAccess(query);
                        MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                        MessageBox.Show("Успешное изменение звонка", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.calls);
                        
                    }
                }
                else MessageBox.Show("Дата старта больше чем дата конца");
            }
            else MessageBox.Show("Вы не указали дату");
        }

        private void Click_Cancel_Call_Redact(object sender, RoutedEventArgs e)
        {
            // отмена действий и переход на главное окно
            MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Call_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                string vs = $"DELETE FROM [calls] WHERE [Код] = " + call_itm.id.ToString() + "";
                MainWindow.connect.QueryAccess(vs);
                MessageBox.Show("Успешное удаление звонка", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.calls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public bool CheckTime(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            string[] str1 = str.Split(':');
            if (str1.Length != 2) return false;

            if (int.TryParse(str1[0].Trim(), out int hours) &&
                int.TryParse(str1[1].Trim(), out int minutes))
            {
                return hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59;
            }
            return false;
        }
    }
}
