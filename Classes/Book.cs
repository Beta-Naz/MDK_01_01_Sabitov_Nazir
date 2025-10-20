using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Сабитов.Classes
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public Book(int id, string name, List<Genre> genres, List<Author> authors, int year) 
        { 
            Id = id;
            Name = name;
            Genres = genres;
            Authors = authors;
            Year = year;
        }
        public static List<Book> AllBook()
        {
            List<Book> allBook = new List<Book>()
            {
                new Book(1, "Путешествие в Казахстан",
                    Genre.AllGenres().FindAll(x => x.Id == 1),
                    Author.AllAuthors().FindAll(x => x.Id == 1), 2023),
                new Book(2, "Чапаев и Пустота",
                    Genre.AllGenres().FindAll(x => x.Id == 1),
                    Author.AllAuthors().FindAll(x => x.Id == 1), 2008),
                new Book(3, "Дебют с пюре. Том 1",
                    Genre.AllGenres().FindAll(x => x.Id == 2),
                    Author.AllAuthors().FindAll(x => x.Id == 2), 2023),
                new Book(4, "Дебют с пюре. Том 2",
                    Genre.AllGenres().FindAll(x => x.Id == 2),
                    Author.AllAuthors().FindAll(x => x.Id == 2), 2023),
                new Book(5, "Четкое название",
                    Genre.AllGenres().FindAll(x => x.Id == 2 || x.Id == 3 || x.Id == 4),
                    Author.AllAuthors().FindAll(x => x.Id == 3), 2022),
            };
            return allBook;
        }
        public string ToGenres()
        {
            string toGenres = "";
            for(int iGenre = 0; iGenre < this.Genres.Count; iGenre++)
            {
                toGenres += this.Genres[iGenre].Name;
                if(iGenre < this.Genres.Count - 1)
                {
                    toGenres += ", ";
                }
            }
            return toGenres;
        }
        public string ToAuthors()
        {
            string toAuthors = "";
            for (int iAuthor = 0; iAuthor < this.Authors.Count; iAuthor++)
            {
                toAuthors += this.Authors[iAuthor].FIO;
                if (iAuthor < this.Authors.Count - 1)
                {
                    toAuthors += ", ";
                }
            }
            return toAuthors;
        }
    }
}
