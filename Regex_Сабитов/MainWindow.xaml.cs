using Regex_Сабитов.Classes;
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

namespace Regex_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Passport> Passports = new List<Passport>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            Passports.Add(new Passport()
            {
                Name = "Назир",
                FirstName = "Сабитов",
                Forename = "Назипович",
                Issued = "ГУ МВД",
                DateOfIssued = "12.10.2019",
                DepartmentCode = "678-423",
                SeriesAndNumber = "5721896025",
                DateOfBirth ="10.04.2005",
                PlaceOfBirth = "Пермский край, с.Лобаново"
            });
            Passports.Add(new Passport()
            {
                Name = "Иван",
                FirstName = "Ширинкин",
                Forename = "Сергеевич",
                Issued = "ГУ МВД",
                DateOfIssued = "23.10.2017",
                DepartmentCode = "678-423",
                SeriesAndNumber = "5721353412",
                DateOfBirth = "12.01.2003",
                PlaceOfBirth = "Пермский край, с.Каштаново"
            });
            for(int i = 0; i < 10; i++)
            {
                Passports.Add(RepoRandomPassport.RandomPassport());
            }
            LoadPassport();
        }
        public void LoadPassport()
        {
            lv_passport.Items.Clear();
            foreach (Passport Passport in Passports)
                lv_passport.Items.Add(Passport);
        }

        private void Add(object sender, RoutedEventArgs e) =>
            new Windows.Add(null).ShowDialog();

        private void Update(object sender, RoutedEventArgs e)
        {
            if(lv_passport.SelectedIndex >-1)
            {
                new Windows.Add(lv_passport.SelectedItem as Passport).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItem as Passport);
                LoadPassport();
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Poisk(object sender, TextChangedEventArgs e)
        {
            lv_passport.Items.Clear();
            if (string.IsNullOrEmpty(PoiskText.Text))
            {
                LoadPassport();
                return;
            }
            string[] fIO = PoiskText.Text.ToLower().Trim().Split(',',' ');
            if(fIO.Length > 3)
            {
                PoiskText.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                PoiskText.Background = new SolidColorBrush(Colors.White);
            }
            foreach (var passport in Passports)
            {
                bool permission = false;
                if (passport.Name.ToLower().Contains(fIO[0]))
                {
                    if (fIO.Length > 1)
                    {
                        if (passport.FirstName.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.Forename.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                        else if (passport.Forename.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.FirstName.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                    }
                    else
                    {
                        permission = true;
                    }
                }
                else if (passport.FirstName.ToLower().Contains(fIO[0]))
                {
                    if (fIO.Length > 1)
                    {
                        if (passport.Name.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.Forename.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                        else if (passport.Forename.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.Name.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                    }
                    else
                    {
                        permission = true;
                    }
                }
                else if (passport.Forename.ToLower().Contains(fIO[0]))
                {
                    if (fIO.Length > 1)
                    {
                        if (passport.FirstName.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.Name.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                        else if (passport.Name.ToLower().Contains(fIO[1]))
                        {
                            if (fIO.Length > 2)
                            {
                                if (passport.FirstName.ToLower().Contains(fIO[2]))
                                {
                                    permission = true;
                                }
                            }
                            else
                            {
                                permission = true;
                            }
                        }
                    }
                    else
                    {
                        permission = true;
                    }
                }
                if (permission)
                {
                    lv_passport.Items.Add(passport);
                }
            }
        }
    }
}
