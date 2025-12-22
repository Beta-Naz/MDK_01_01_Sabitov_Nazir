namespace Shop_Сабитов.Models
{
    public class Shop
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Shop(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}
