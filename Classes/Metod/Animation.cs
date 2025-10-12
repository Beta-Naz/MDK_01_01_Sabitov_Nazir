using Batlle_Сабитов.Elements;
using Batlle_Сабитов.Elements.Anim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Batlle_Сабитов.Classes.Metod
{
    public class Animation
    {
        private static System.Timers.Timer timer;
        private static void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Elapsed -= TimerForAvoidance;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
        public static void StartTimers(string count)
        {
            DisposeTimer();
            timer = new Timer(16);
            if(count == "Avoidance")
            {
                timer.Elapsed += TimerForAvoidance;
            }
            timer.AutoReset = false;
            timer.Start();
        }
        private static void TimerForAvoidance(object sender, ElapsedEventArgs e)
        {
            Batlle.init.Dispatcher.Invoke(() =>
            {
                StartAvoidance();
            });
        }
        public static void StartAvoidance()
        {
            if (Batlle.init.TextAvoidance.Content.ToString().Trim() == "")
            {
                Batlle.init.TextAvoidance.Content = "УКЛОНЕНИЕ";
            }
            Batlle.init.Avoidance.Height -= 10;
            if (Batlle.init.Avoidance.Height == 0)
            {
                Batlle.init.TextAvoidance.Content = "";
                Batlle.init.Avoidance.Height = 250;
            }
            else
            {
                StartTimers("Avoidance");
            }
        }
    }
}
