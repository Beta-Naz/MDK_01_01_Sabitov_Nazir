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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Практическая_работа_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] imageMonster = new string[] { "Slime", "Golem", "Mimic" }; 

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimerTwo = new DispatcherTimer();
        /// <summary>
        /// Коллекция противников
        /// </summary>
        public List<Classes.PersonInfo> Enemys = new List<Classes.PersonInfo>();

        public Classes.PersonInfo Enemy;

        /// <summary>
        /// Данные игрока
        /// </summary>
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);
        public MainWindow()
        {
            InitializeComponent();
            // Повышаем уровень персонажа и обновляем данные на UI
            UserInfoPlayer();
            //Добавляем данные о противниках в коллекцию
            Enemys.Add(new Classes.PersonInfo("Слайм", 100, 20, 1, 15, 5, 25));
            Enemys.Add(new Classes.PersonInfo("Голем", 200, 80, 1, 40, 5, 30));
            Enemys.Add(new Classes.PersonInfo("Мимик", 40, 20, 1, 70, 10, 45));

            dispatcherTimerTwo.Tick += AutoAttackEnemy;
            dispatcherTimerTwo.Interval = new System.TimeSpan(0, 0, 2);
            dispatcherTimerTwo.Start();

            // Задаём настройки для таймера
            dispatcherTimer.Tick += AttackPlayer;
            // Задаём интервал с которым выполняется таймер
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            // Запускаем таймер
            dispatcherTimer.Start();
            //Случайный враг
            SelectEnemy();
        }

        /// <summary>
        /// Выбор случайного противника
        /// </summary>
        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemys.Count);
            emptyImage.Source = new BitmapImage(new Uri($"Image/{imageMonster[Id]}.png", UriKind.Relative));
            Enemy = new Classes.PersonInfo(
                Enemys[Id].Name,
                Enemys[Id].Health,
                Enemys[Id].Armor,
                Enemys[Id].Level,
                Enemys[Id].Glasses,
                Enemys[Id].Money,
                Enemys[Id].Damage);
        }

        /// <summary>
        /// Повышение уровня и обновление данных на UI
        /// </summary>
        public void UserInfoPlayer()
        {
            if(Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;

                Player.Glasses = 0;

                Player.Health += 100;

                Player.Damage++;

                Player.Armor++;
            }
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {
            Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));
            if(Enemy.Health <= 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                emptyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }

        /// <summary>
        /// Метод, который наносит переодически урон игроку
        /// </summary>
        private void AttackPlayer(object sender, System.EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }
        private void AutoAttackEnemy(object sender, System.EventArgs e)
        {
            Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));
            if (Enemy.Health <= 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                emptyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }
    }
}
