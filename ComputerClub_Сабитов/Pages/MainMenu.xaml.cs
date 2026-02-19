using System;
using System.Windows;
using System.Windows.Controls;

namespace ComputerClub_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainWindow _currentMainWindow;
        public event Action ChangeItem;
        private bool _change = true;
        public bool Change
        {
            get
            {
                return _change;
            }
            set
            {
                if( _change != value)
                {
                    _change = value;
                    OnChanged();
                }
            }
        }
        public void OnChanged()
        {
            ChangeItem?.Invoke();
        }
        public MainMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            _currentMainWindow = mainWindow;
            ChangeItem += LoadData;
            OnChanged();
        }
        public void LoadData()
        {
            if(_change)
            {
                
            }
            else
            {

            }
            Title.Text = Change ? "Компьютерные клубы" : "Игровые компьютеры";
        }
        private void Club_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
