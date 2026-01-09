namespace Shop_Сабитов.Models
{
    public class Sport : Shop
    {
        public string Size { get; set; }
        public int IdShop { get; set; }
        public Sport() { }
        public Sport(int id, string Name, int Price, string Size, int idShop, string src, int discount) : base(id, Name, Price, src, discount)
        {
            this.Size = Size;
            IdShop = idShop;
        }
    }
}
