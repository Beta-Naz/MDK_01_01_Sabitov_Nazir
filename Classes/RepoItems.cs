using System.Collections.Generic;
using Shop_Сабитов.Models;

namespace Shop_Сабитов.Classes
{
    public class RepoItems
    {
        public static List<object> AllItems()
        {
            List<object> allItems = new List<object>
            {
                new Children("Игрушка интерактивная", 2200, 3),
                new Children("Кактус", 1400, 8),
                new Children("Дакимакура Пикачу", 5600, 12),
                new Sport("Спортивный мужской костюм", 4913, "S"),
                new Sport("Мяч для водного поло", 812, "61-63 см"),
                new Sport("Набор для гольфа Sigma", 3950, "600*800 мм"),
                new Electronics("Машинка на радио управлении", 9990, 100, 15),
                new Electronics("Тополь на радио управлении", 29990, 100, 15)
            };
            return allItems;
        }
    }
}
