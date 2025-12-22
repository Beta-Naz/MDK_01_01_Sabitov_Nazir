namespace Shop_Сабитов.Models
{
    public class Sport : Shop
    {
        public string Size { get; set; }
        public Sport(string Name, int Price, string Size) : base(Name, Price)
        {
            this.Size = Size;
        }
    }
}
