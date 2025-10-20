using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Book_Сабитов.Classes;
using Microsoft.Win32;
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
            Cr();
        }
        public void Cr()
        {
            AddAuthors();
            AddGenres();
            AddYears();
            CreateUI(AllBooks);
        }
        public void AddAuthors()
        {
            cdAuthors.Items.Clear();
            cdAuthors.Items.Add("Выберите ...");
            foreach (Classes.Author author in AllAuthors)
            {
                cdAuthors.Items.Add(author.FIO);
            }
        }
        public void AddGenres()
        {
            cdGenres.Items.Clear();
            cdGenres.Items.Add("Выберите ...");
            foreach (Classes.Genre genres in AllGenres)
            {
                cdGenres.Items.Add(genres.Name);
            }
        }
        public void AddYears()
        {
            cdYear.Items.Clear();
            cdYear.Items.Add("Выберите ...");
            List<int> AllYears = new List<int>();
            foreach (Classes.Book book in AllBooks)
            {
                if (AllYears.Find(x => x == book.Year) == 0)
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
            List<Classes.Book> FindBook = AllBooks.FindAll(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower()));
            if (cdAuthors.SelectedIndex > 0)
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

        private void Import(object sender, RoutedEventArgs e)
        {
            string nameDan = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Отжать данные из текстового файла";
            if (openFileDialog.ShowDialog() != null)
            {
                string filePath = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filePath);
                AllAuthors = new List<Author>();
                AllGenres = new List<Genre>();
                AllBooks = new List<Book>();
                foreach (string line in lines)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    if (line == "Авторы:")
                    {
                        nameDan = line;
                        continue;
                    }
                    if (line == "Жанры:")
                    {
                        nameDan = line;
                        continue;
                    }
                    else if (line == "Книги:")
                    {
                        nameDan = line;
                        continue;
                    }
                    string[] info = line.Trim().Split(',', ';');
                    switch (nameDan)
                    {
                        case "Авторы:":
                            AllAuthors.Add(new Author(int.Parse(info[0]), info[1]));
                            break;
                        case "Жанры:":
                            AllGenres.Add(new Genre(int.Parse(info[0]), info[1]));
                            break;
                        case "Книги:":
                            string[] Genres = line.Split('(', ')');
                            string[] Genre = Genres[1].Split(',');
                            List<Genre> genres = new List<Genre>();
                            foreach (string genre in Genre)
                            {
                                genres.Add(AllGenres.Find(x => x.Name == genre.Trim()));
                            }
                            AllBooks.Add(new Book(int.Parse(info[0]), info[1], genres,
                                AllAuthors.FindAll(x => x.FIO == info[2]), 2));
                            break;
                    }
                }
                Cr();
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    

        private void Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Сохранить текстовый файл";
            if (saveFileDialog.ShowDialog() != null)
            {
                string filePath = saveFileDialog.FileName;
                string info = "Авторы:\n";
                foreach (Classes.Author author in AllAuthors)
                {
                    info +=  $"{author.Id},{author.FIO};\n";
                }
                info += "Жанры:\n";
                foreach (Classes.Genre genres in AllGenres)
                {
                    info += $"{genres.Id},{genres.Name};\n";
                }
                info += "Книги:\n";
                foreach (Classes.Book book in AllBooks)
                {
                    info += $"{book.Id},{book.Name},{book.ToAuthors()},({book.ToGenres()}),{book.Year};\n";
                }
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine(info);
                writer.Close();
                MessageBox.Show($"Файл сохранен: {filePath}");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
