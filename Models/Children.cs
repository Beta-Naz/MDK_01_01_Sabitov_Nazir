namespace Shop_Сабитов.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }

        public Children(string Name, int Price, int Age) : base(Name, Price)
        {
            this.Age = Age;
        }
    }
}
