namespace Shop_Сабитов.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Src { get; set; }
        public int Discount { get; set; }
        public Shop() { }
        public Shop(int id, string Name, int Price, string src, int discount)
        {
            this.Name = Name;
            this.Price = Price;
            Id = id;
            Src = src;
            Discount = discount;
        }
    }
}
