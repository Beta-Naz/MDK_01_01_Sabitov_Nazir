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
    /// Логика взаимодействия для VyButton.xaml
    /// </summary>
    public partial class VyButton : UserControl
    {
        public static VyButton init;
        public VyButton()
        {
            InitializeComponent();
            init = this;
        }
        private static System.Timers.Timer timer;
        private static void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Elapsed -= TimerForBack;
                timer.Elapsed -= TimerForTitri;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
        public static void StartTimers()
        {
            timer = new Timer(5000);
            timer.Elapsed += TimerForBack;
            timer.AutoReset = false;
            timer.Start();
        }
        private static void TimerForBack(object sender, ElapsedEventArgs e)
        {
            init.Dispatcher.Invoke(() =>
            {
                ContVictory();
            });
        }
        public static void ContVictory()
        {
            PeacefulWorld.init.VictoryButton.Children.Add(new Elements.VyButton());
            DisposeTimer();
        }
        private void Victory_Click(object sender, RoutedEventArgs e)
        {
            if (PeacefulWorld.init.EndVictory.Foreground == new SolidColorBrush(Colors.Green))
            {
                Batlle_Сабитов.MainWindow.init.Close();
                return;
            }
            PeacefulWorld.CountLocations++;
            PeacefulWorld.init.VictoryButton.Children.Clear();
            if(!(PeacefulWorld.CountLocations >= Classes.Locations.RepoAllLocations.AllEndLocations().Count))
            {
                PeacefulWorld.init.ImagesVictory.Source = new BitmapImage(new Uri(
                    Classes.Locations.RepoAllLocations.AllEndLocations()[PeacefulWorld.CountLocations].BackgroundLocations));
            }
            if (PeacefulWorld.CountLocations >= Classes.Locations.RepoAllLocations.AllEndLocations().Count - 1)
            {
                DisposeTimer();
                StartTimersForTitri();
            }
            else
            {
                StartTimers();
            }
        }
        public static void StartTimersForTitri()
        {
            DisposeTimer();
            timer = new Timer(5);
            timer.Elapsed += TimerForTitri;
            timer.AutoReset = false;
            timer.Start();
        }
        private static void TimerForTitri(object sender, ElapsedEventArgs e)
        {
            init.Dispatcher.Invoke(() =>
            {
                Titri();
            });
        }
        public static void Titri()
        {
            if (PeacefulWorld.init.Titri.Height == 200)
            {
                PeacefulWorld.init.EndVictory.Foreground = new SolidColorBrush(Colors.Green);
                PeacefulWorld.init.EndVictoryText.Foreground = new SolidColorBrush(Colors.Green);
                PeacefulWorld.init.VictoryButton.Children.Add(new Elements.VyButton());
                if(init.VictorButton.Content != null)
                {
                    init.VictorButton.Content = "Спасибо за игру";
                }
            }
            else
            {
                PeacefulWorld.init.Titri.Height--;
                StartTimersForTitri();
            }
        }
    }
}
