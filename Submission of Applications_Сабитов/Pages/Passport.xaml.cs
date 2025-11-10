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
using Microsoft.Win32;
using static Submission_of_Applications_Сабитов.MainWindow;

namespace Submission_of_Applications_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Passport.xaml
    /// </summary>
    public partial class Passport : Page
    {
        bool tr;
        bool ttr = false;
        public Passport()
        {
            InitializeComponent();

        }
        private void contuniePages(object sender, RoutedEventArgs e)
        {
            firstName_TextChanged(null,null);
            if (tr)
            {
                name_TextChanged(null, null);
                if (tr)
                {
                    forename_TextChanged(null, null);
                    if (tr)
                    {
                        dateOfBirth_TextChanged(null, null);
                        if (tr)
                        {
                            gras_TextChanged(null, null);
                            if (tr)
                            {
                                placeOfBirth_TextChanged(null, null);
                                if (tr)
                                {
                                    seriaAndNomer_TextChanged(null, null);
                                    if (tr)
                                    {
                                        dateOfAdd_TextChanged(null, null);
                                        if (tr)
                                        {
                                            code_TextChanged(null, null);
                                            if (tr)
                                            {
                                                kem_TextChanged(null, null);
                                                if (tr)
                                                {
                                                    addresForpropiske_TextChanged(null, null);
                                                    if (tr)
                                                    {
                                                        raion1_TextChanged(null, null);
                                                        if (tr)
                                                        {
                                                            addres_TextChanged(null, null);
                                                            if (tr)
                                                            {
                                                                raion2_TextChanged(null, null);
                                                                if (tr)
                                                                {
                                                                    if (ttr)
                                                                    {
                                                                        init.OpenPages(pages.contacts);
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Укажите фото паспорта");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(firstName.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                firstName.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                firstName.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(name.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                name.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                name.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void forename_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(forename.Text, "^[а-яА-Я0-9\\s,.ёЁ]*$"))
            {
                tr = true;
                forename.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                forename.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void dateOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(dateOfBirth.Text, "^[0-3]{1}[0-9]{1}.[01]{1}[0-9]{1}.\\d{4}$"))
            {
                tr = true;
                dateOfBirth.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                dateOfBirth.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void gras_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(gras.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                gras.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                gras.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void placeOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(placeOfBirth.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                placeOfBirth.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                placeOfBirth.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void seriaAndNomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(seriaAndNomer.Text, "^\\d{10}$"))
            {
                tr = true;
                seriaAndNomer.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                seriaAndNomer.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void dateOfAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(dateOfAdd.Text, "^[0-3]{1}[0-9]{1}.[01]{1}[0-9]{1}.\\d{4}$"))
            {
                tr = true;
                dateOfAdd.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                dateOfAdd.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(code.Text, "^\\d{3}-\\d{3}$"))
            {
                tr = true;
                code.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                code.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void kem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(kem.Text, "^[А-Я0-9\\s,.Ё]+$"))
            {
                tr = true;
                kem.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                kem.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void addresForpropiske_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(addresForpropiske.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                addresForpropiske.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                addresForpropiske.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void raion1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(raion1.Text, "^[а-яА-Я0-9\\s,.ёЁ]*$"))
            {
                tr = true;
                raion1.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                raion1.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void addres_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(addres.Text, "^[а-яА-Я0-9\\s,.ёЁ]+$"))
            {
                tr = true;
                addres.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                addres.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void raion2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Match(raion2.Text, "^[а-яА-Я0-9\\s,.ёЁ]*$"))
            {
                tr = true;
                raion2.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                tr = false;
                raion2.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void OpenImg(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "images (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string type = openFileDialog.SafeFileName.Split('.')[1];
                if (type != "png" && type != "jpeg" && type != "pdf")
                {
                    MessageBox.Show("Формат документов должен быть PNG, JPEG или PDF", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ttr = true;
                sourseImg.Text = openFileDialog.FileName;
            }
        }
    }
}
