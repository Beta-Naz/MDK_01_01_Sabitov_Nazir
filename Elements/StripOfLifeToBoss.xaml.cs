using Batlle_Сабитов.Classes;
using System.Windows.Controls;

namespace Batlle_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для StripOfLifeToBoss.xaml
    /// </summary>
    public partial class StripOfLifeToBoss : UserControl
    {
        public static StripOfLifeToBoss init;
        public StripOfLifeToBoss(AlwaysMonsters Boss)
        {
            InitializeComponent();
            init = this;
            TextHealtBoss.Content = Boss.Healt;
        }

    }
}
