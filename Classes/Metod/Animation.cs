using Batlle_Сабитов.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Batlle_Сабитов.Classes.Metod
{
    public class Animation
    {
        private static System.Timers.Timer timer;
        public static void StartTimers()
        {
            timer = new Timer(2);
            timer.Elapsed += TimerForAvoidance;
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
            Batlle.init.Avoidance.Height -= 1;
            if (Batlle.init.Avoidance.Height == 0)
            {
                Batlle.init.TextAvoidance.Content = "";
                Batlle.init.Avoidance.Height = 250;
            }
            else
            {
                StartTimers();
            }
        }
    }
}
