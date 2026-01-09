namespace Shop_Сабитов.Models
{
    public class Sport : Shop
    {
        public string Size { get; set; }
        public Sport(int id, string Name, int Price, string Size) : base(id, Name, Price)
        {
            this.Size = Size;
        }
    }
}
