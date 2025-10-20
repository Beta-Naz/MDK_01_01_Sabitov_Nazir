using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Book_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Element.xaml
    /// </summary>
    public partial class Element : UserControl
    {
        public Element(Classes.Book book)
        {
            InitializeComponent();
            tbName.Text = $"Наименование: {book.Name} ({book.Year} г.)";
            tbGenre.Text = $"Жанр: {book.ToGenres()}";
            tbAuthor.Text = $"Автор: {book.ToAuthors()}";
        }
    }
}
