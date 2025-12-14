using ClassConnection;
using ClassModule;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PhoneBook_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public enum page_main
        {
            users, calls, none
        };
        // действующая страница
        public static page_main page_select;

        public Main()
        {
            InitializeComponent();
            page_select = page_main.none;
        }

        // действие при нажатии на кнопку с клиентами
        private void Click_Phone(object sender, RoutedEventArgs e)
        {
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.users)
            {
                page_select = page_main.users;

                // добавляем анимации переходов
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgridAnimation1 = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.2)
                    };
                    opgridAnimation1.Completed += delegate
                    {
                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);

                            foreach (User user_itm in MainWindow.connect.users)
                            {
                                if (page_select == page_main.users)
                                {
                                    parrent.Children.Add(new Elements.User_itm(user_itm));
                                    await Task.Delay(90);
                                }
                            }

                            if (page_select == page_main.users)
                            {
                                var ff = new Pages.PagesUser.User_win(new User());
                                parrent.Children.Add(new Elements.Add_itm(ff));
                            }
                        });
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation1);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        // действие при нажатии на кнопку с историей звонков
        private void Click_History(object sender, RoutedEventArgs e)
        {
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.calls)
            {
                page_select = page_main.calls;

                DoubleAnimation oppgridAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                oppgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation oppgridAnimation1 = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.2)
                    };
                    oppgridAnimation1.Completed += delegate
                    {
                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(ClassConnection.Connection.tabels.calls);

                            foreach (Call call_itm in MainWindow.connect.calls)
                            {
                                if (page_select == page_main.calls)
                                {
                                    parrent.Children.Add(new Elements.Call_itm(call_itm));
                                    await Task.Delay(90);
                                }
                            }

                            if (page_select == page_main.calls)
                            {
                                var ff = new Pages.PagesUser.Call_win(new ClassModule.Call());
                                parrent.Children.Add(new Elements.Add_itm(ff));
                            }
                        });
                    };

                    parrent.BeginAnimation(StackPanel.OpacityProperty, oppgridAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, oppgridAnimation);
            }
        }

        // Функция анимированного перехода по страницам
        public void Anim_move(Control control, Control control2, Frame frame_main = null, Page pages = null, page_main page_restart = page_main.none)
        {
            if (page_restart != page_main.none)
            {
                if (page_restart == page_main.users)
                {
                    page_select = page_main.none;
                    Click_Phone(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.calls)
                {
                    page_select = page_main.none;
                    Click_History(new object(), new RoutedEventArgs());
                }
            }
            else
            {
                DoubleAnimation oppgridAnimation = new DoubleAnimation();
                oppgridAnimation.From = 1;
                oppgridAnimation.To = 0;
                oppgridAnimation.Duration = TimeSpan.FromSeconds(0.3);
                oppgridAnimation.Completed += delegate
                {
                    if (pages != null)
                    {
                        frame_main.Navigate(pages);
                        //if (control1 == frame_main && control2 == frame_main)
                        // if (Mainindow.actualUser.role != "admin")
                        // {
                        //     parent.Children.Clear();
                        // }
                    }

                    //control1.Visibility = Visibility.Hidden;
                    control2.Visibility = Visibility.Visible;

                    DoubleAnimation oppgridAnimation1 = new DoubleAnimation();
                    oppgridAnimation1.From = 0;
                    oppgridAnimation1.To = 1;
                    oppgridAnimation1.Duration = TimeSpan.FromSeconds(0.4);

                    control2.BeginAnimation(ScrollViewer.OpacityProperty, oppgridAnimation1);
                };

                //control1.BeginAnimation(ScrollViewer.OpacityProperty, oppgridAnimation);
            }
        }
    }
}
