using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для SpecificationsAndStore.xaml
    /// </summary>
    public partial class SpecificationsAndStore : UserControl
    {
        public static SpecificationsAndStore init;
        public SpecificationsAndStore()
        {
            InitializeComponent();
            init = this;
            foreach (Classes.Object.MedicinalPotions item in Classes.Object.RepoMedicinalPotions.AllMedicinalPotions)
            {
                Shop.Children.Add(new Elements.Object(item));
            }
            foreach (Classes.Object.Weapon item in Classes.Object.RepoWeapon.AllWeapon)
            {
                if (!item.СanUse)
                {
                    Shop.Children.Add(new Elements.Object(item));
                }
            }
            foreach (Classes.Object.Items objec in Classes.Metod.Variables.ОbjectForInvety)
            {
                Inventory.Children.Add(new Elements.ObjectProductToInvent(objec));
            }
            UpdateStat();
        }
        public static void UpdateStat()
        {
            init.TextHealtPlayer.Content = Math.Round(Classes.Player.Healt, 0);
            init.PlayerLevel.Content =Math.Round(Classes.Player.Levels,0);
            init.PlayerSkillPoints.Content = Math.Round(Classes.Player.FreeLevels, 0);
            init.PlayerDamage.Content = Math.Round(Classes.Player.Damage, 0);
            init.PlayerArmor.Content = Math.Round(Classes.Player.Armor, 0);
            init.PlayerMaxHealt.Content = Math.Round(Classes.Player.MaxHealt, 0);
            init.PlayerDexterity.Content = Math.Round(Classes.Player.Dexterity, 0);
            init.PlayerName.Content = Classes.Player.Name;
            init.PlayerTypeArmor.Content = Classes.Player.TypeArmor;
            init.PlayerImages.Source = new BitmapImage(new Uri(Classes.Player.Images));
            if(Classes.Player.TypeWeapon != null)
            {
                init.WeaponImages.Source = new BitmapImage(new Uri(Classes.Player.TypeWeapon.Images));
            }
            else
            {
                init.WeaponImages.Source = new BitmapImage(new Uri("pack://application:,,,/Batlle_Сабитов;component/Images/Object/Без_оружия.png"));
            }
            init.PlayerMoney.Content = Classes.Player.Money;
            UpdateHealtBarPlayer();
        }
        public static void UpdateHealtBarPlayer()
        {
            double difference = Classes.Player.Healt / Classes.Player.MaxHealt;
            init.HealtBarPlayer.Width = init.HealtMaxBarPlayer.Width * difference;
        }
        private void UppHealt_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.Player.FreeLevels > 0)
            {
                Classes.Player.FreeLevels--;
                Classes.Player.MaxHealt *= 1.1;
                UpdateStat();
            }
        }
        private void UppDamage_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Player.FreeLevels > 0)
            {
                Classes.Player.FreeLevels--;
                Classes.Player.Damage *= 1.1;
                UpdateStat();
            }
        }
        private void UppDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Player.FreeLevels > 0 && Classes.Player.MaxUppDexterity != 20)
            {
                Classes.Player.FreeLevels--;
                Classes.Player.Dexterity += 1;
                Classes.Player.MaxUppDexterity += 1;
                UpdateStat();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Batlle_Сабитов.MainWindow.init.MinWidth = 800;
            Batlle_Сабитов.MainWindow.init.Width = 800;
            Batlle_Сабитов.MainWindow.init.MinHeight = 500;
            Batlle_Сабитов.MainWindow.init.MinHeight = 500;
            Classes.AddMonster.AddWorldMap();
        }
    }
}
