using System.Collections.Generic;

namespace Book_Сабитов.Classes
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public static List<Genre> AllGenres()
        {
            List<Genre> allGenres = new List<Genre>()
            {
                new Genre(1, "Современная русская литература"),
                new Genre(2, "Современные детективы"),
                new Genre(3, "Любовное фентэзи"),
                new Genre(4, "Исекай"),
                new Genre(5, "Юмористическое фэнтези"),
            };

            return allGenres;
        }
    }
}
