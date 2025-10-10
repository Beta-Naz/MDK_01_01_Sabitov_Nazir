using Batlle_Сабитов.Classes;
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

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Batlle.xaml
    /// </summary>
    public partial class Batlle : UserControl
    {
        public static bool startTimer = false;
        private System.Timers.Timer turnTimer;
        public static Batlle init;
        int turn;
        int monsterTurn;
        public Batlle()
        {
            InitializeComponent();
            StopTimer();
            turn = 0;
            monsterTurn = 0;

            init = this;
            NeedMetod.RandomCountMosters();
            PlayerHealt.Content = $"Здоровье: {Player.Healt}/{Player.MaxHealt}";
            PlayerDamage.Content = $"Урон: " + Player.Damage;
            PlayerDexterity.Content = $"Ловкость: " + Player.Dexterity;
            PlayerEXP.Content = $"Опыт:  " + Player.EXP;
            PlayerImages.Source = new BitmapImage(new Uri(Player.Images));
            PlayerName.Content = Player.Name;
            PlayerName.Foreground = NeedMetod.Color[Player.ColorName];
            BackGround.Source = new BitmapImage(new Uri(CreateLocations.LastLocationSourse));

            Classes.Turn.ResetColorTurns();
            Player.ValidAttack = true;

            TurnOne.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
            TurnTwo.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[1].WhoseMove];
            TurnThree.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[2].WhoseMove];
            if (Classes.Turn.Turns.Count >= 4)
            {
                TurnFour.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[3].WhoseMove];
                if (Classes.Turn.Turns.Count >= 5)
                {
                    TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[4].WhoseMove];
                    turn = 4;
                }
                else
                {
                    TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
                    turn = 0;
                }
            }
            else
            {
                TurnFour.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[0].WhoseMove];
                TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[1].WhoseMove];
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
            init.turn++;
            if (init.turn >= Classes.Turn.Turns.Count)
            {
                init.turn = 0;
            }
            init.TurnFive.Background = Classes.Turn.ColorsToTurn[Classes.Turn.Turns[init.turn].WhoseMove];
            if (init.TurnOne.Background != Classes.Turn.ColorsToTurn["Player"])
            {
                init.monsterTurn ++;
                if (!startTimer)
                {
                    init.StartTimer();
                    startTimer = true;
                    Player.ValidAttack = false;
                }
            }
            else
            {
                init.monsterTurn = 0;
                startTimer = false;
                Player.ValidAttack = true;
                init.StopTimer();
            }
        }
        public static void AttackMonster(double damageMonster)
        {
            double damage = NeedMetod.MinusHealtForPlayer(damageMonster);
            if (Player.Healt - damage <= 0)
            {
                Player.Healt = 0;
                init.PlayerHealt.Content = $"Здоровье: {Player.Healt}/{Player.MaxHealt}";
            }
            else
            {
                Player.Healt -= damage;
                init.PlayerHealt.Content = $"Здоровье: {Player.Healt}/{Player.MaxHealt}";
            }
            СhangeTurn();
        }
        private void StartTimer()
        {
            turnTimer = new Timer(3000);
            turnTimer.Elapsed += TimerForAttackMonsters;
            turnTimer.AutoReset = true;
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
        public void StopTimer()
        {
            turnTimer?.Stop();
            turnTimer?.Dispose();
        }
    }
}
