using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Submission_of_Applications_Сабитов
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
            OpenPages(pages.statement);
        }
        public enum pages
        {
            statement,
            education,
            status,
            speciality,
            passport,
            contacts,
            parents
        }

        public void OpenPages(pages _page)
        {
            switch(_page)
            {
                case pages.statement: frame.Navigate(new Pages.Statement()); break;
                case pages.education: frame.Navigate(new Pages.Education()); break;
                case pages.status: frame.Navigate(new Pages.Status()); break;
                case pages.speciality: frame.Navigate(new Pages.Speciality()); break;
                case pages.passport: frame.Navigate(new Pages.Passport()); break;
                case pages.contacts: frame.Navigate(new Pages.Contacts()); break;
                case pages.parents: frame.Navigate(new Pages.Parents()); break;
            }
        }

        public static bool Match(string a, string b)
        {
            Match m = Regex.Match(a, b);
            return m.Success;
        }
    }
}
