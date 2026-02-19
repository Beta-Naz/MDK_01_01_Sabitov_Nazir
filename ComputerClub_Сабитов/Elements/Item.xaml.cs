using ComputerClub_Сабитов.Core.Context;
using ComputerClub_Сабитов.Core.Enums;
using ComputerClub_Сабитов.Pages;
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

namespace ComputerClub_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private MainWindow _currentMainWindow;
        private MainMenu _currentMain;
        private object _currentObject;
        public Item(MainWindow mainWindow, MainMenu main, object obj)
        {
            InitializeComponent();
            _currentMainWindow = mainWindow;
            _currentMain = main;
            if(obj == null)
            {
                _currentMain.parrent.Children.Remove(this);
                return;
            }
            _currentObject = obj;
            if(obj is ContextCompiterClub club)
            {
                Id.Text = club.Id.ToString();
                Name.Text = club.Name.ToString();
                StartAndEndTime.Text = club.StartTimeWork.ToString("g") + "-" + club.EndTimeWork.ToString("g");
                Address.Text = club.Address.ToString();
            }
            else if(obj is ContextPlayerComputer player)
            {
                Id.Text = player.Id.ToString();
                Name.Text = player.FullName.ToString();
                StartAndEndTime.Text = player.StartTimeRent.ToString("g") + "-" + player.EndTimeRent.ToString("g");
                parrent.Children.Remove(Address);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _currentMain.parrent.Children.Remove(this);
            if (_currentObject is ContextCompiterClub club)
            {
                club.Delete();
            }
            else if (_currentObject is ContextPlayerComputer player)
            {
                player.Delete();
            }
            _currentMain.OnChanged();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _currentMainWindow.LoadPages(PageType.addPage, _currentObject);
        }
    }
}
