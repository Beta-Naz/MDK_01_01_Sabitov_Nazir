using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace Human_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int count = 0;
        public System.Timers.Timer timer;
        public static MediaPlayer MediaPlayer = new MediaPlayer();
        private Classes.Russian Russian = new Classes.Russian("Александр", @"C:\Users\student-a502\Desktop\Human_Сабитов\Images\ic_russian.png");
        private Classes.English English = new Classes.English("Alena", @"C:\Users\student-a502\Desktop\Human_Сабитов\Images\ic_english.png");
        private Classes.Deutsch Deutsch = new Classes.Deutsch("Sasha", @"C:\Users\student-a502\Desktop\Human_Сабитов\Images\ic_deutsch.png");
        public static List<Elements.Item> items = new List<Elements.Item>(); 
        public MainWindow()
        {
            var russian = new Elements.Item(Russian);
            var english = new Elements.Item(English);
            var deutsch = new Elements.Item(Deutsch);

            items.Add(russian);
            items.Add(english);
            items.Add(deutsch);

            InitializeComponent();
            parent.Children.Add(items[0]);
            parent.Children.Add(items[1]);
            parent.Children.Add(items[2]);
        }
        private void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Elapsed -= TimerDialog;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
        public void StartTimers()
        {
            DisposeTimer();
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += TimerDialog;
            timer.AutoReset = false;
            timer.Start();
        }
        private void TimerDialog(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Dialog();
            });
        }

        private void Dialog_Click(object sender, RoutedEventArgs e)
        {
            StartTimers();
        }
        public void Dialog()
        {
            items[count % items.Count].Speak(null, null);
            count++;
            if(count == 10)
            {
                DisposeTimer();
            }
            else
            {
                StartTimers();
            }
        }
    }
}
