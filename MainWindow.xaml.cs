using Batlle_Сабитов.Classes;
using System.Windows;

namespace Batlle_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            AddMonster.AddСhoiceCharacter();
            //В этой практике среди кода, спрятанна пасхалка!
            //Спасибо вам, за эту практику, мне она очень понравилась
        }
    }
}
