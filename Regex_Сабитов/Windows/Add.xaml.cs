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
using System.Windows.Shapes;

namespace Regex_Сабитов.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;
        public Add(Classes.Passport editPassports)
        {
            InitializeComponent();
            if(editPassports != null )
            {
                Name.Text = editPassports.Name;
                FirstName.Text = editPassports.FirstName;
                Forename.Text = editPassports.Forename;
                Issued.Text = editPassports.Issued;
                DateOfIssued.Text = editPassports.DateOfIssued;
                DepartmentCode.Text = editPassports.DepartmentCode;
                SeriesAndNumber.Text = editPassports.SeriesAndNumber;
                DateOfBirth.Text = editPassports.DateOfBirth;
                PlaceOfBirth.Text = editPassports.PlaceOfBirth;
                EditPassports = editPassports;
                BthAdd.Content = "Изменить";
            }
        }
        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[a-яА-Я]*$", Name.Text))
            {
                MessageBox.Show("Неправильно указали имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(FirstName.Text) || !Classes.Common.CheckRegex.Match("^[a-яА-Я]*$", FirstName.Text))
            {
                MessageBox.Show("Неправильно указали фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(Forename.Text) || !Classes.Common.CheckRegex.Match("^[a-яА-Я]*$", Forename.Text))
            {
                MessageBox.Show("Неправильно указали отчество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match("^[А-Я0-9\\s\\-\"\".,()/]+$", Issued.Text))
            {
                MessageBox.Show("Неправильно указали паспорт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}[.-]\\d{2}[.-]\\d{4}$", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указали дату выдачи паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^\\d{3}-\\d{3}$", DepartmentCode.Text))
            {
                MessageBox.Show("Неправильно указали дату код подразделения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("^\\d{10}$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Неправильно указали серию и номер", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}[.-]\\d{2}[.-]\\d{4}$", DateOfBirth.Text))
            {
                MessageBox.Show("Неправильно указали дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-ЯёЁ0-9\\s\\-.,()/]+$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Неправильно указали место рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }
            EditPassports.Name = Name.Text;
            EditPassports.FirstName = FirstName.Text;
            EditPassports.Forename = Forename.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;
            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}
