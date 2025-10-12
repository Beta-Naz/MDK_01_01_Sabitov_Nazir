using Batlle_Сабитов.Classes.Metod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Batlle_Сабитов.Elements.Anim
{
    /// <summary>
    /// Логика взаимодействия для AnimTextDamageMonsterxaml.xaml
    /// </summary>
    public partial class AnimTextDamageMonsterxaml : UserControl
    {
        int count;
        int x = 0;
        public static AnimTextDamageMonsterxaml init;
        private static System.Timers.Timer timer;
        public AnimTextDamageMonsterxaml(double damage, string nameMonster, int count)
        {
            InitializeComponent();
            init = this;
            this.count = count;
            Damage.Content = Math.Round(damage,1);
            Damage.Foreground = Classes.Turn.ColorsToTurn[nameMonster];
            StartTimers();
        }
        public void StartDamagePlayer()
        {
            var spawn = new[]
            {
                Batlle.init.DamageFromMonstr_1,
                Batlle.init.DamageFromMonstr_2,
                Batlle.init.DamageFromMonstr_3,
            };
            if (init.DamageConteiner.Margin == new Thickness(0, 0, 0, 200))
            {
                spawn[count].Children.Remove(AnimTextDamageMonsterxaml.init);
                timer.Stop();
                timer.Dispose();
            }
            else
            {
                DamageConteiner.Margin = new Thickness(0, 0, 0, x);
                StartTimers();
                x += 10;
            }
        }
        private void TimerForDamagePlayer(object sender, ElapsedEventArgs e)
        {
            Batlle.init.Dispatcher.Invoke(() =>
            {
                StartDamagePlayer();
            });
        }
        public void StartTimers()
        {
            timer = new System.Timers.Timer(16);
            timer.Elapsed += TimerForDamagePlayer;
            timer.AutoReset = false;
            timer.Start();
        }
    }
}
