namespace Shop_Сабитов.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }
        public int IdShop { get; set; }
        public Children() {}
        public Children(int id, string Name, int Price, int Age, int IdShop) : base(id, Name, Price)
        {
            this.Age = Age;
            this.IdShop = IdShop;
        }
    }
}
