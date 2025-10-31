using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace TimeLord_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        public static MediaPlayer MediaPlayer = new MediaPlayer();
        public DispatcherTimer dispatcherTimer = new();
        public float full_second = 0;
        public bool start_timer = false;
        public Timer()
        {
            InitializeComponent();
            dispatcherTimer.Tick += TimerSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            if (!start_timer)
            {
                if (!ValidTimer())
                {
                    return; 
                }
                string [] hoursMinutsSeconds = time.Text.Split(':');
                full_second = int.Parse(hoursMinutsSeconds[0]) * 60 * 60 + int.Parse(hoursMinutsSeconds[1]) * 60 + int.Parse(hoursMinutsSeconds[2]);
                dispatcherTimer.Start();
                start_timer = true;
                start.Content = "Стоп";
            }
            else
            {
                Stop();
            }
        }
        private bool ValidTimer()
        {
            if (string.IsNullOrEmpty(time.Text) || !Match("^\\d{2}:\\d{2}:\\d{2}$", time.Text))
            {
                time.Background = new SolidColorBrush(Colors.Red);
                return false;
            }
            time.Background = new SolidColorBrush(Colors.Transparent);
            return true;
        }
        private void TimerSecond(object sender, EventArgs e)
        {
            if (!ValidTimer() || Time(full_second) != time.Text)
            {
                dispatcherTimer.Stop();
                start_timer = false;
                start.Content = "Начать";
                return;
            }
            full_second--;
            time.Text = Time(full_second);
            if (full_second == 0)
            {
                Sound();
                dispatcherTimer.Stop();
                return;
            }
        }
        private string Time(float fullSecond)
        {
            float hours = (int)(fullSecond / 60 / 60);
            float minuts = (int)(fullSecond / 60) - (hours * 60);
            float seconds = fullSecond - (hours * 60 * 60) - (minuts * 60);

            string s_seconds = seconds.ToString();
            if (seconds < 10)
            {
                s_seconds = "0" + seconds;
            }
            string s_minuts = minuts.ToString();
            if (minuts < 10)
            {
                s_minuts = "0" + minuts;
            }
            string s_hours = hours.ToString();
            if (hours < 10)
            {
                s_hours = "0" + hours;
            }
            return s_hours + ":" + s_minuts + ":" + s_seconds;
        }
        private void Stop()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFE8E100");
            timerBackground.Background = new SolidColorBrush(color);
            dispatcherTimer.Stop();
            start_timer = false;
            start.Content = "Начать";
            MediaPlayer.Stop();
        }
        private void Stopwatch(object sender, RoutedEventArgs e)
        {
            Stop();
            OpenPages(pages.stopwatch);
        }
        public enum pages
        {
            stopwatch
        }
        public void OpenPages(pages _page)
        {
            if (_page == pages.stopwatch)
            {
                MainWindow.init.frame.Navigate(new Pages.Stopwatch());
            }
        }
        public static bool Match(string pattern, string input)
        {
            Match m = Regex.Match(input, pattern);
            return m.Success;
        }
        public void Sound()
        {
            //C:\Users\Сабитов Назир\Desktop\MDK_01_01_Sabitov_Nazir--15\TimeLord_Сабитов\Sound\wow.mp3
            string source = "Sound/wow.mp3";
            MediaPlayer.Open(new Uri(source, UriKind.Relative));
            MediaPlayer.Play();
            timerBackground.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
