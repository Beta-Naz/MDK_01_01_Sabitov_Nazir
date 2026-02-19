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
        public List<object> allObject = new ContextCompiterClub().GetAll().
            Concat(new ContextPlayerComputer().GetAll()).ToList();  
        public MainWindow()
        {
            InitializeComponent();
            _pages = new List<object>();
            LoadPages(PageType.mainPage);
        }
        public void LoadPages(PageType type, object obj = null)
        {
            switch (type)
            {
                case PageType.mainPage:
                    MainMenu menu = null;
                    foreach (var page in _pages)
                    {
                        if(page is MainMenu)
                        {
                            menu = page as MainMenu;
                        }
                    }
                    if(menu == null)
                    {
                        menu = new MainMenu(this);
                        _pages.Add(menu);
                    }
                    menu.OnChanged();
                    frame.Navigate(menu);
                    break;
                case PageType.addPage:
                    AddPage add = null;
                    MainMenu menu1 = null;
                    foreach (var page in _pages)
                    {
                        if (page is MainMenu)
                        {
                            add = page as AddPage;
                        }
                        else if (menu1 is MainMenu)
                        {
                            menu1 = page as MainMenu;
                        }
                    }
                    if (add == null)
                    {
                        add = new AddPage(this, obj, menu1);
                        _pages.Add(add);
                    }
                    frame.Navigate(add);
                    break;
            }
        }
    }
}
