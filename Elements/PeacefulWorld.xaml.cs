using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для PeacefulWorld.xaml
    /// </summary>
    public partial class PeacefulWorld : UserControl
    {
        int tr = 0;
        public static int CountLocations = 3;
        private static System.Timers.Timer timer;
        public static Random random = new Random();
        public static PeacefulWorld init;
        public PeacefulWorld()
        {
            InitializeComponent();
            init = this;
            StartTimers();
        }
        ~PeacefulWorld()
        {
            DisposeTimer();
        }
        public static void StartTimers()
        {
            DisposeTimer();
            timer = new Timer(5000);
            timer.Elapsed += TimerForBack;
            timer.AutoReset = false;
            timer.Start();
        }
        public static void StartAnimation()
        {
            timer = new Timer(3);
            timer.Elapsed += TimerAnim;
            timer.AutoReset = false;
            timer.Start();
        }
        private static void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Elapsed -= TimerForBack;
                timer.Elapsed -= TimerAnim;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
        private static void TimerAnim(object sender, ElapsedEventArgs e)
        {
            init.Dispatcher.Invoke(() =>
            {
                StartAnim();
            });
        }
        private static void TimerForBack(object sender, ElapsedEventArgs e)
        {
            init.Dispatcher.Invoke(() =>
            {
                StartVictory();
            });
        }
        public static void StartVictory()
        {
            if(init.tr == 0)
            {
                init.tr ++;
                StartTimers();
            }
            else if(init.tr == 1)
            {
                init.tr ++;
                StartTimers();
            }
            else if(init.tr == 2)
            {
                init.VictoryButton.Children.Add(new Elements.VyButton());
            }
            init.ImagesVictory.Source = new BitmapImage(new Uri(
                Classes.Locations.RepoAllLocations.AllEndLocations()[2].BackgroundLocations));
            StartAnimation();

        }
        public static void StartAnim()
        {
            Random rnd = new Random();
            int dir = rnd.Next(1, 5);
            int x = rnd.Next(1, 21);
            switch (dir)
            {
                case 1:
                    init.Anim.Margin = new Thickness(x, 0, 0, 0);
                    break;
                case 2:
                    init.Anim.Margin = new Thickness(0, x, 0, 0);
                    break;
                case 3:
                    init.Anim.Margin = new Thickness(0, 0, x, 0);
                    break;
                case 4:
                    init.Anim.Margin = new Thickness(0, 0, 0, x);
                    break;
            }
            if(init.tr == 2)
            {
                init.Anim.Margin = new Thickness(0, 0, 0, 0);
                init.ImagesVictory.Source = new BitmapImage(new Uri(
                    Classes.Locations.RepoAllLocations.AllEndLocations()[3].BackgroundLocations));
            }
            else
            {
                StartAnimation();
            }
        }
    }
}
