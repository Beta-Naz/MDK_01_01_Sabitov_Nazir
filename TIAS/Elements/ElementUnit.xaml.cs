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
using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Models;

namespace TIAS.Elements
{
    /// <summary>
    /// Логика взаимодействия для ElementUnit.xaml
    /// </summary>
    public partial class ElementUnit : UserControl
    {
        public Unit CurrentUnit { get; private set; }
        private readonly int stadtartWitdh = 30;
        public ElementUnit(Unit unit)
        {
            InitializeComponent();
            CurrentUnit = unit;
            LoadImages();
            CurrentUnit.OnTakeDamage += UpdateHealtBar;
        }
        public void UpdateHealtBar()
        {
            double multiHealth = stadtartWitdh / CurrentUnit.MaxHealth;
            HealtBar.Width = CurrentUnit.Health > 0 ? CurrentUnit.Health * multiHealth : 0;
        }
        void LoadImages()
        {
            if (CurrentUnit is Tank tank)
            {
                if(tank.NameAlliance == TypeAlliance.USSR)
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/T34.png", UriKind.Relative));
                }
                else
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/Panjer.png", UriKind.Relative));
                }
            }
            else if(CurrentUnit is Infanity infa)
            {
                if (infa.NameAlliance == TypeAlliance.USSR)
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/infanity_germany.png", UriKind.Relative));
                }
                else
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/infanity_germany.png", UriKind.Relative));
                }
            }
            else if(CurrentUnit is Artillery arta)
            {
                if (arta.NameAlliance == TypeAlliance.USSR)
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/art1.png", UriKind.Relative));
                }
                else
                {
                    UnitImage.Source = new BitmapImage(new Uri("/Images/Unit/art2.png", UriKind.Relative));
                }
            }
        }
        private void Unit_Click(object sender, MouseButtonEventArgs e)
        {
            if(MainWindow.Instance.SelectUnit == null)
            {
                MainWindow.Instance.SelectUnit = CurrentUnit;
            }
            else if (MainWindow.Instance.SelectUnit.NameAlliance != CurrentUnit.NameAlliance)
            {
                MainWindow.Instance.SelectUnit.Attack(CurrentUnit);
                MainWindow.Instance.SelectUnit = null;
            }
            else
            {
                MainWindow.Instance.SelectUnit = null;
            }
        }
    }
}
