using Batlle_Сабитов.Classes;
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

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Batlle.xaml
    /// </summary>
    public partial class Batlle : UserControl
    {
        private static System.Timers.Timer turnTimer;
        public static Batlle init;
        public static int turn;
        public Batlle()
        {
            InitializeComponent();
            turn = 0;

            init = this;
            Classes.Metod.SpawnMonsters.RandomCountMosters();
            PlayerHealt.Content = $"Здоровье: {Math.Round(Player.Healt,0)}/{Math.Round(Player.MaxHealt, 0)}";
            PlayerDamage.Content = $"Урон: " + Math.Round(Player.Damage, 0);
            PlayerDexterity.Content = $"Ловкость: " + Math.Round(Player.Dexterity, 0);
            PlayerEXP.Content = $"Опыт:  " + Player.EXP;
            PlayerImages.Source = new BitmapImage(new Uri(Player.Images));
            PlayerName.Content = Player.Name;
            PlayerName.Foreground = Classes.Metod.Variables.Color[Player.ColorName];
            BackGround.Source = new BitmapImage(new Uri(Classes.Locations.CreateLocations.LastLocationSourse));

            Classes.Turn.ResetColorTurns();
            Player.ValidAttack = true;

            init.TurnOne.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
            init.TurnTwo.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[1].WhoseMove];
            init.TurnThree.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[2].WhoseMove];
            if (Classes.Turn.Turns.Count >= 4)
            {
                init.TurnFour.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[3].WhoseMove];
                if (Classes.Turn.Turns.Count >= 5)
                {
                    init.TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[4].WhoseMove];
                    turn = 4;
                }
                else
                {
                    init.TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
                    turn = 0;
                }
            }
            else
            {
                init.TurnFour.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
                init.TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[1].WhoseMove];
                turn = 1;
            }
        }
        private void Player_Click(object sender, MouseButtonEventArgs e)
        {

        }
        public static void СhangeTurn()
        {
            init.TurnOne.Background = init.TurnTwo.Background;
            init.TurnTwo.Background = init.TurnThree.Background;
            init.TurnThree.Background = init.TurnFour.Background;
            init.TurnFour.Background = init.TurnFive.Background;
            turn++;
            if (turn >= Classes.Turn.Turns.Count)
            {
                turn = 0;
            }
            init.TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[turn].WhoseMove];
            if (init.TurnOne.Background != Classes.Turn.ColorsToTurn["Player"])
            {
                init.StartTimer();
                Player.ValidAttack = false;
            }
            else
            {
                Player.ValidAttack = true;
            }
        }
        public static void AttackMonster(double damageMonster)
        {
            double damage = Classes.Metod.AttackAndProtection.MinusHealtForPlayer(damageMonster);
            if (Player.Healt - damage <= 0)
            {
                Player.Healt = 0;
                init.PlayerHealt.Content = $"Здоровье: {Math.Round(Player.Healt, 0)}/{Math.Round(Player.MaxHealt, 0)}";
                MainWindow.init.MainGameWindow.Children.Clear();
                MainWindow.init.MainGameWindow.Children.Add(new Elements.GameOver());
            }
            else
            {
                Player.Healt -= damage;
                init.PlayerHealt.Content = $"Здоровье: {Math.Round(Player.Healt, 0)}/{Math.Round(Player.MaxHealt, 0)}";
            }
            СhangeTurn();
        }
        private static void DisposeTimer()
        {
            if (turnTimer != null)
            {
                turnTimer.Elapsed -= init.TimerForAttackMonsters;
                turnTimer.Stop();
                turnTimer.Dispose();
                turnTimer = null;
            }
        }
        private void StartTimer()
        {
            DisposeTimer();
            turnTimer = new System.Timers.Timer(2000);
            turnTimer.Elapsed += TimerForAttackMonsters;
            turnTimer.AutoReset = false;
            turnTimer.Start();
        }
        private void TimerForAttackMonsters(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (init.TurnOne.Background == Classes.Turn.ColorsToTurn["First"])
                {
                    AttackMonster(AlwaysMonsters.WhatSpawnMonsters[0].Damage);
                }
                else if (init.TurnOne.Background == Classes.Turn.ColorsToTurn["Second"])
                {
                    AttackMonster(AlwaysMonsters.WhatSpawnMonsters[1].Damage);
                }
                else if (init.TurnOne.Background == Classes.Turn.ColorsToTurn["Third"])
                {
                    AttackMonster(AlwaysMonsters.WhatSpawnMonsters[2].Damage);
                }
                else if (init.TurnOne.Background == Classes.Turn.ColorsToTurn["Fourth"])
                {
                    AttackMonster(AlwaysMonsters.WhatSpawnMonsters[3].Damage);
                }
            });
        }
    }
}
