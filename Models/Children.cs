namespace Shop_Сабитов.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }
        public int IdShop { get; set; }
        public Children() {}
        public Children(int id, string Name, int Price, int Age, int IdShop, string src, int discount) : base(id, Name, Price, src, discount)
        {
            this.Age = Age;
            this.IdShop = IdShop;
        }
    }
}
