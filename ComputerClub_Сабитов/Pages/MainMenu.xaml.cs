using ComputerClub_Сабитов.Core.Context;
using ComputerClub_Сабитов.Core.DataBaseHelper;
using ComputerClub_Сабитов.Core.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ComputerClub_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainWindow _currentMainWindow;
        public DispatcherTimer timer;
        public event Action ChangeItem;
        private static bool _change = true;
        public RoleType? Role = null;
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
            if(Role == null)
            {
                return;
            }
            Title.Text = Change ? "Компьютерные клубы" : "Игровые компьютеры";
            parrent.Children.Clear();
            List<object> objects = _currentMainWindow.AllObject(Role);
            if(objects == null)
            {
                MessageBox.Show("objects == null");
                return;
            }
            foreach (var obj in objects)
            {
                if (_change)
                {
                    if (obj is ContextCompiterClub item)
                    {
                        if (!Filter(obj))
                        {
                            continue;
                        }
                        parrent.Children.Add(new Elements.Item(_currentMainWindow, this, item));
                    }
                }
                else
                {
                    if (obj is ContextPlayerComputer item)
                    {
                        if (!Filter(obj))
                        {
                            continue;
                        }
                        parrent.Children.Add(new Elements.Item(_currentMainWindow, this, item));
                    }
                }
            }
        }
        private void Club_Click(object sender, RoutedEventArgs e)
        {
            if (!Change)
            {
                Change = true;
            }
        }
        private void Player_Click(object sender, RoutedEventArgs e)
        {
            if(Change)
            {
                Change = false;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _currentMainWindow.LoadPages(PageType.addPage);
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }
        bool Filter(object obj)
        {
            if (string.IsNullOrEmpty(Search.Text))
            {
                return true;
            }
            string text = Search.Text.Trim().ToLower();
            if (obj is ContextCompiterClub club)
            {
                MessageBox.Show($"{club.Name.ToLower()}");
                return club.Id.ToString().ToLower().Contains(text)
                    || club.Name.ToLower().Contains(text)
                    || club.StartTimeWork.ToString("yyyy-MM-dd HH:mm:ss").ToLower().Contains(text)
                    || club.EndTimeWork.ToString("yyyy-MM-dd HH:mm:ss").ToLower().Contains(text)
                    || club.Address.ToLower().Contains(text);
            }
            if (obj is ContextPlayerComputer play)
            {
                return play.Id.ToString().ToLower().Contains(text)
                    || play.FullName.ToLower().Contains(text)
                    || play.StartTimeRent.ToString("yyyy-MM-dd HH:mm:ss").ToLower().Contains(text)
                    || play.EndTimeRent.ToString("yyyy-MM-dd HH:mm:ss").ToLower().Contains(text);
            }
            return false;
        }
        
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBConnection.UserId = NameUser.Text;
                DBConnection.Password = PasswordUser.Text;
                MySqlConnection connection = DBConnection.Connection();
                if(connection != null)
                {
                    Role = DBConnection.TestConnectionRole(connection);
                    switch (Role)
                    {
                        case RoleType.Admin:
                            PanelRegister.Visibility = Visibility.Collapsed;
                            BtnC.Visibility = Visibility.Visible;
                            BtnP.Visibility = Visibility.Visible;
                            Change = true;
                            break;
                        case RoleType.User:
                            BtnC.Visibility = Visibility.Collapsed;
                            BtnP.Visibility = Visibility.Collapsed;
                            PanelRegister.Visibility = Visibility.Collapsed;
                            Change = false;
                            break;
                        default:
                             MessageBox.Show("Проблемы со входом");
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка: неверный логин или пароль");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            PanelRegister.Visibility = Visibility.Visible;
        }
    }
}
