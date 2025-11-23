using System.Collections.Generic;

namespace FurnitureStore_Сабитов.Classes
{
    public class Item
    {
        public string name { get; set; }
        public int price { get; set; }
        public string src { get; set; }
        public List<string> type { get; set; }
        public Item(string name, int price, string src, List<string> type)
        {
            this.name = name;
            this.price = price;
            this.src = src;
            this.type = type;
        }
    }
}
