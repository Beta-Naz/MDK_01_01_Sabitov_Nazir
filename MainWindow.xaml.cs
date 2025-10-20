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
using Book_Сабитов.Classes;

namespace Book_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Classes.Author> AllAuthors = Classes.Author.AllAuthors();
        List<Classes.Genre> AllGenres = Classes.Genre.AllGenres();
        List<Classes.Book> AllBooks = Classes.Book.AllBook();
        public MainWindow()
        {
            InitializeComponent();
            AddAuthors();
            AddGenres();
            AddYears();

            CreateUI(AllBooks);
        }
        public void AddAuthors()
        {
            cdAuthors.Items.Add("Выберите ...");
            foreach (Classes.Author author in AllAuthors)
            {
                cdAuthors.Items.Add(author.FIO);
            }
        }
        public void AddGenres()
        {
            cdGenres.Items.Add("Выберите ...");
            foreach (Classes.Genre genres in AllGenres)
            {
                cdGenres.Items.Add(genres.Name);
            }
        }
        public void AddYears()
        {
            cdGenres.Items.Add("Выберите ...");
            List<int> AllYears = new List<int>();
            foreach (Classes.Book book in AllBooks)
            {
                if(AllYears.Find(x => x == book.Year) == 0)
                {
                    AllYears.Add(book.Year);
                    cdYear.Items.Add(book.Year);
                }
            }
        }
        public void CreateUI(List<Classes.Book> AllBooks)
        {
            parent.Children.Clear();
            foreach (Classes.Book book in AllBooks)
            {
                parent.Children.Add(new Elements.Element(book));
            }
        }

        private void SelectAuthor(object sender, SelectionChangedEventArgs e) => Search();

        private void SelectGenres(object sender, SelectionChangedEventArgs e) => Search();

        private void SelectYear(object sender, SelectionChangedEventArgs e) => Search();

        private void Search_Book(object sender, KeyEventArgs e) => Search();
        public void Search()
        {
            List<Classes.Book> FindBook = AllBooks.FindAll(x =>  x.Name.ToLower().Contains(tbSearch.Text.ToLower()));
            if(cdAuthors.SelectedIndex > 0)
            {
                Classes.Author SelectAuthor = AllAuthors.Find(x => x.FIO == cdAuthors.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x => x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);
            }
            if (cdGenres.SelectedIndex > 0)
            {
                Classes.Genre SelectGenre = AllGenres.Find(x => x.Name == cdGenres.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x => x.Genres.Find(y => y.Id == SelectGenre.Id) != null);
            }
            if (cdYear.SelectedIndex > 0)
            {
                FindBook = FindBook.FindAll(x => x.Year == Convert.ToInt32(cdYear.SelectedItem.ToString()));
            }
            CreateUI(FindBook);
        }
    }
}
