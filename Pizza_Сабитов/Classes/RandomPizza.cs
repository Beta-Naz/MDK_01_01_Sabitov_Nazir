using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Pizza_Сабитов.Classes
{
    public class RandomPizza
    {
        Random rd = new Random();
        List<string> AllIngredients = new List<string>() 
        {
            "соус <<Кунжутный>>",
            "сыр <<Моцарелла>>",
            "сыр <<Моцарелла>> мягкий",
            "соус <<Кунжутный>>",
            "помидоры",
            "кетчуп",
            "маойнез",
            "огурцы",
            "ананас",
            "докторская колбоса"
        };
        List<string> AllDescriptions = new List<string>()
        {
            "Пи́цца - итальянское национальное блюдо в виде круглой открытой дрожжевой лепёшки",
            "Пи́цца - вкусное и сытное блюдо",
            "Пи́цца - лучший подарок для друга",
            "Пи́цца - ничто так не сближает, как кусочек пиццы",
            "Пи́цца - в этом слове всего пять букв, а вместили весь мир по частям",
        };
        List<string> AllNames = new List<string>()
        {
            "Сливочная",
            "Нежная",
            "Сочная",
            "Домашняя",
            "Солянка",
            "Аппетитная",
            "Ароматная",
            "Итальянская",
            "Хрустящая",
            "Пряная",
            "Пикантная",
            "Румяная",
            "Золотистая",
            "Воздушная",
            "Тонкая",
            "Пышная",
            "Пахнущая",
            "Дымная",
            "Свежая",
            "Горячая",
            "Парящая",
            "Тающая",
            "Изумительная",
            "Божественная",
            "Сытная",
            "Насыщенная",
            "Многослойная",
            "Яркая",
            "Колоритная",
            "Фирменная",
            "Авторская",
            "Особенная",
        };
        public List<Dish.Ingredient> RandomIngredients()
        {
            int count = rd.Next(3,6);
            List<Dish.Ingredient> ingredients = new List<Dish.Ingredient>();
            for (int i = 0; i < count; i++)
            {
                int x = rd.Next(0, AllIngredients.Count);
                for (; ;)
                {
                    bool copy = true;
                    foreach (Dish.Ingredient ingredient1 in ingredients)
                    {
                        if (ingredient1.name == $"{AllIngredients[x]}")
                        {
                            copy = false;
                        }
                    }
                    if (copy)
                    {
                        break;
                    }
                    x = rd.Next(0, AllIngredients.Count);
                }
                ingredients.Add(new Dish.Ingredient { name = $"{AllIngredients[x]}" });
            }
            return ingredients;
        }
        public string RandomDescription()
        {
            int x = rd.Next(0, AllDescriptions.Count);
            return AllDescriptions[x];
        }
        public string RandomName()
        {
            int x = rd.Next(0, AllNames.Count);
            if(AllNames.Count == 0)
            {
                return "Рандомная пицца(попробуй и узнай вкус)";
            }
            string name = AllNames[x];
            AllNames.Remove(name);
            return name;
        }
        public Dish RandomDish()
        {
            Dish newDish = new Dish()
            {
                img = "img-" + $"{rd.Next(0,28)}",
                name = RandomName(),
                description = RandomDescription(),
                ingredients = RandomIngredients(),
                sizes = new List<Dish.Sizes>()
                {
                    new Dish.Sizes
                    {
                        size = rd.Next(20,26),
                        price = rd.Next(300,601),
                        wes = rd.Next(500,601)
                    },
                    new Dish.Sizes
                    {
                        size = 30,
                        price = rd.Next(650,951),
                        wes = rd.Next(600,901)
                    },
                    new Dish.Sizes
                    {
                        size = 40,
                        price = rd.Next(1000,1401),
                        wes = rd.Next(900,1201)
                    }
                }
            };
            return newDish;
        }
    }
}
