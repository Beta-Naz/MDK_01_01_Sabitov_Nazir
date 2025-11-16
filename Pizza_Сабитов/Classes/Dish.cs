using System.Collections.Generic;

namespace Pizza_Сабитов.Classes
{
    public class Dish
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Sizes> sizes = new List<Sizes>();
        public string img;
        public List<Ingredient> ingredients = new List<Ingredient>();
        public string description;
        public int activeSize = 0;

        public class Sizes
        {
            public int id;
            public int id_size;
            public int size;
            public int price;
            public int wes;

            public int countOrder;
            public bool orders;

            public int totalCount = 0;
        }
        public class Ingredient
        {
            public int id;
            public string name;
            public int price;
            public int wes;

            public string img;
            public int count;
        }
    }
}
