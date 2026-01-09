namespace Shop_Сабитов.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }

        public Children(int id, string Name, int Price, int Age) : base(id, Name, Price)
        {
            this.Age = Age;
        }
    }
}
