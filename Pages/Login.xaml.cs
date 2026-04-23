using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using ChatStudents_Sabitov.Classes;
using ChatStudents_Sabitov.Models;

namespace ChatStudents_Sabitov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string SrcUserImage = "";
        private Dictionary<System.Windows.Controls.TextBox, string[]> _textBoxKeys = new();
        private UsersContext _usersContext = new();
        public Login()
        {
            InitializeComponent();
            Serialize();
        }
        private void Serialize()
        {
            _textBoxKeys[Lastname] = new string[] {"^[А-ЯёЁ][а-яА-ЯёЁ]*$","Укажите фамилию"};
            _textBoxKeys[Firstname] = new string[] { "^[А-ЯёЁ][а-яА-ЯёЁ]*$", "Укажите имя" };
            _textBoxKeys[Surname] = new string[] { "^[А-ЯёЁ][а-яА-ЯёЁ]*$", "Укажите отчество" };
        }
        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "Выберите фотографию",
                InitialDirectory = @"C:\",
                Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                SrcUserImage = openFileDialog.FileName;
            }
        }
        private void Continue(object sender, RoutedEventArgs e)
        {
            foreach (var obj in _textBoxKeys)
            {
                if (!CheckEmpty(obj.Value[0], obj.Key.Text))
                {
                    System.Windows.MessageBox.Show(obj.Value[1]);
                    return;
                }
            }
            if (string.IsNullOrEmpty(SrcUserImage) || !File.Exists(SrcUserImage))
            {
                System.Windows.MessageBox.Show("Выберите изображение.");
                return;
            }
            if (FirstUser() != null)
            {
                MainWindow.Instance.LoginUser = FirstUser();
                MainWindow.Instance.LoginUser.Photo = File.ReadAllBytes(SrcUserImage);
            }
            else
            {
                _usersContext.Users.Add(new User(
                    Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(SrcUserImage)));
                MainWindow.Instance.LoginUser = FirstUser();
            }
            _usersContext.SaveChanges();
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
        private User FirstUser()
        {
            return _usersContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                   x.Lastname == Lastname.Text &&
                                   x.Surname == Surname.Text).First();
        }
        public bool CheckEmpty(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }
    }
}
