using Batlle_Сабитов.Classes;
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
    /// Логика взаимодействия для UserGameWindow.xaml
    /// </summary>
    public partial class UserGameWindow : UserControl
    {
        public UserGameWindow()
        {
            InitializeComponent();
        }
        private void Lb_Click(object sender, MouseButtonEventArgs e)
        {
            string[] healt = LbHealt.Content.ToString().Trim().Split(' ');
            string[] damage = LbDamage.Content.ToString().Trim().Split(' ');
            string[] armor = LbArmor.Content.ToString().Trim().Split(' ');
            string[] dexterity = LbDexterity.Content.ToString().Trim().Split(' ');
            string name = LbName.Content.ToString();
            string color = LbName.Foreground.ToString();
            string[] typeArmor = LbTypeArmor.Content.ToString().Trim().Split(' ');
            string images = LbImages.Source.ToString();
            Vibor(double.Parse(healt[1]), double.Parse(damage[1]), 
                double.Parse(armor[1]), double.Parse(dexterity[1]), 
                name, typeArmor[1], images, color);
        }

        private void Mb_Click(object sender, MouseButtonEventArgs e)
        {
            string[] healt = MbHealt.Content.ToString().Trim().Split(' ');
            string[] damage = MbDamage.Content.ToString().Trim().Split(' ');
            string[] armor = MbArmor.Content.ToString().Trim().Split(' ');
            string[] dexterity = MbDexterity.Content.ToString().Trim().Split(' ');
            string name = MbName.Content.ToString();
            string color = MbName.Foreground.ToString();
            string[] typeArmor = MbTypeArmor.ToString().Trim().Split(' ');
            string images = MbImages.Source.ToString();
            Vibor(double.Parse(healt[1]), double.Parse(damage[1]),
                double.Parse(armor[1]), double.Parse(dexterity[1]),
                name, typeArmor[1], images, color);
        }

        private void Hb_Click(object sender, MouseButtonEventArgs e)
        {
            string[] healt = HbHealt.Content.ToString().Trim().Split(' ');
            string[] damage = HbDamage.Content.ToString().Trim().Split(' ');
            string[] armor = HbArmor.Content.ToString().Trim().Split(' ');
            string[] dexterity = HbDexterity.Content.ToString().Trim().Split(' ');
            string name = HbName.Content.ToString();
            string color = HbName.Foreground.ToString();
            string[] typeArmor = HbTypeArmor.Content.ToString().Trim().Split(' ');
            string images = HbImages.Source.ToString();
            Vibor(double.Parse(healt[1]), double.Parse(damage[1]),
                double.Parse(armor[1]), double.Parse(dexterity[1]),
                name, typeArmor[1], images, color);
        }
        public static void Vibor(double Healt, double Damage, double Armor, 
            double Dexterity, string Name, string TypeArmor, string Images, string ColorName)
        {
            Classes.Player.MaxHealt = Healt;
            Classes.Player.Healt = Healt;
            Classes.Player.Damage = Damage;
            Classes.Player.Armor = Armor;
            Classes.Player.Dexterity = Dexterity;
            Classes.Player.Name = Name;
            Classes.Player.TypeArmor = TypeArmor;
            Classes.Player.Images = Images;
            Classes.Player.ColorName = ColorName;
            AddMonster.AddWorldMap();
        }
    }
}
