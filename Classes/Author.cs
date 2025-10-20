using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Сабитов.Classes
{
    public class Author
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public Author(int id, string fIO)
        {
            Id = id;
            FIO = fIO;
        }
        public static List<Author> AllAuthors()
        {
            List<Author> allAuthors = new List<Author>()
            {
                new Author(1, "Виктор Пелевин"),
                new Author(2, "Александр Маринина"),
                new Author(3, "Ольга Герр"),
            };
            return allAuthors;
        }
    }
}
