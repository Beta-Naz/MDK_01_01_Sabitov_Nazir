namespace Shop_Сабитов.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Shop(int id, string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
            Id = id;
        }
    }
}
