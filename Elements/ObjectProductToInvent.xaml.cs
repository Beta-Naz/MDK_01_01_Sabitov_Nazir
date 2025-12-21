using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для ObjectProductToInvent.xaml
    /// </summary>
    public partial class ObjectProductToInvent : UserControl
    {
        public object Product;
        public ObjectProductToInvent(object Product)
        {
            InitializeComponent();
            this.Product = Product;
            Classes.Object.Items product = Product as Classes.Object.Items;
            ImagesProduct.Source = new BitmapImage(new Uri(product.Images));
            NameProduct.Content = product.Name;
            if (Product is Classes.Object.Weapon)
            {
                Classes.Object.Weapon weap = Product as Classes.Object.Weapon;
                DescriptionProduct.Content = $"Множитель урона: {weap.MultiplierDamage}x\n" +
                    $"Крит шанс: {weap.CriticalСhance * 100}%\n" +
                    $"Крит урон: {weap.CriticalDamage}x\n" +
                    $"Снижение ловкости: {weap.DebuffDexterity * 100}%\n";
            }
            if (Product is Classes.Object.MedicinalPotions)
            {
                Classes.Object.MedicinalPotions weap = Product as Classes.Object.MedicinalPotions;
                DescriptionProduct.Content = $"Востановление: {weap.Heal} здоровья";
            }
        }
        private void Use(object sender, MouseButtonEventArgs e)
        {
            if (Product is Classes.Object.Weapon)
            {
                Classes.Object.Weapon product = Product as Classes.Object.Weapon;
                if (Classes.Player.TypeWeapon != null)
                {
                    Elements.SpecificationsAndStore.init.Inventory.Children.Add(new Elements.ObjectProductToInvent(Classes.Player.TypeWeapon));
                    Classes.Metod.Variables.ОbjectForInvety.Add(Classes.Player.TypeWeapon);
                }
                Elements.SpecificationsAndStore.init.Inventory.Children.Remove(this);
                Classes.Metod.Variables.ОbjectForInvety.Remove(product);
                Classes.Player.TypeWeapon = product;
                Elements.SpecificationsAndStore.UpdateStat();
            }
            else if (Product is Classes.Object.MedicinalPotions)
            {
                Classes.Object.MedicinalPotions product = Product as Classes.Object.MedicinalPotions;
                Classes.Player.Healt += product.Heal;
                if (Classes.Player.Healt > Classes.Player.MaxHealt)
                {
                    Classes.Player.Healt = Classes.Player.MaxHealt;
                }
                Elements.SpecificationsAndStore.init.Inventory.Children.Remove(this);
                Classes.Metod.Variables.ОbjectForInvety.Remove(product);
                Elements.SpecificationsAndStore.UpdateStat();
            }
        }
    }
}
