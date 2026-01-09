namespace Shop_Сабитов.Models
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int DrivingSpeed { get; set; }

        public int IdShop { get; set; }
        public Electronics() { }
        public Electronics(int id, string Name, int Price, int BatteryCapacity, int DrivingSpeed, int idShop) : base(id, Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.DrivingSpeed = DrivingSpeed;
            IdShop = idShop;
        }
    }
}
