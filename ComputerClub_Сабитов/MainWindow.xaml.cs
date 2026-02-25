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

namespace ComputerClub_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<object> _pages;
        public List<object> AllObject(RoleType? role)
        {
            if(role == RoleType.Admin)
            {
                return new ContextCompiterClub().GetAll().Concat(new ContextPlayerComputer().GetAll()).ToList();
            }
            else if(role == RoleType.User)
            {
                return new ContextPlayerComputer().GetAll();
            }
            else
            {
                return null;
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            _pages = new List<object>();
            LoadPages(PageType.mainPage);
        }
        public void LoadPages(PageType type, object obj = null)
        {
            MainMenu menu = null;
            foreach (var page in _pages)
            {
                if (page is MainMenu)
                {
                    menu = page as MainMenu;
                    break;
                }
            }
            if (menu == null)
            {
                menu = new MainMenu(this);
                _pages.Add(menu);
            }
            switch (type)
            {
                case PageType.mainPage:
                    menu.OnChanged();
                    frame.Navigate(menu);
                    break;
                case PageType.addPage:
                    AddPage add = new AddPage(this, obj, menu);
                    frame.Navigate(add);
                    break;
            }
        }
    }
}
