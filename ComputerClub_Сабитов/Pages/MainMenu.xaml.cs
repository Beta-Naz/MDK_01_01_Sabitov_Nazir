using ComputerClub_Сабитов.Core.Context;
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
        private static bool _change = true;
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
            Title.Text = Change ? "Компьютерные клубы" : "Игровые компьютеры";
            parrent.Children.Clear();
            foreach (var obj in _currentMainWindow.allObject)
            {
                if (_change)
                {
                    if (obj is ContextCompiterClub item)
                    {
                        parrent.Children.Add(new Elements.Item(_currentMainWindow, this, item));
                    }
                }
                else
                {
                    if (obj is ContextPlayerComputer item)
                    {
                        parrent.Children.Add(new Elements.Item(_currentMainWindow, this, item));
                    }
                }
            }
        }
        private void Club_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            Change = false;
        }
    }
}
