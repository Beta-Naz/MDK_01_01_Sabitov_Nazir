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

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Object.xaml
    /// </summary>
    public partial class Object : UserControl
    {
        public object Product;
        public Object(object Product)
        {
            InitializeComponent();
            this.Product = Product;
            Classes.Object.Items product = Product as Classes.Object.Items;
            ImagesProduct.Source = new BitmapImage(new Uri(product.Images));
            NameProduct.Content = product.Name;
            Price.Content = product.Price;
            if(Product is Classes.Object.Weapon)
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
        private void Buy(object sender, MouseButtonEventArgs e)
        {
            if (Product is Classes.Object.Weapon)
            {
                Classes.Object.Weapon product = Product as Classes.Object.Weapon;
                if (Classes.Player.Money >= product.Price)
                {
                    int x = Classes.Object.RepoWeapon.AllWeapon.FindIndex(a => a == product);
                    Classes.Object.RepoWeapon.AllWeapon[x].СanUse = true;
                    Classes.Player.Money -= product.Price;
                    Elements.SpecificationsAndStore.init.Shop.Children.Remove(this);
                    Elements.SpecificationsAndStore.init.Inventory.Children.Add(new Elements.ObjectProductToInvent(Product));
                    Classes.Metod.Variables.ОbjectForInvety.Add(product);
                    Elements.SpecificationsAndStore.UpdateStat();
                }
            }
            else if (Product is Classes.Object.MedicinalPotions)
            {
                Classes.Object.MedicinalPotions product = Product as Classes.Object.MedicinalPotions;
                if (Classes.Player.Money >= product.Price)
                {
                    Classes.Player.Money -= product.Price;
                    Elements.SpecificationsAndStore.init.Inventory.Children.Add(new Elements.ObjectProductToInvent(Product));
                    Classes.Metod.Variables.ОbjectForInvety.Add(product);
                    Elements.SpecificationsAndStore.UpdateStat();
                }
            }
        }
    }
}
