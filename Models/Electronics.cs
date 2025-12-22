namespace Shop_Сабитов.Models
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int DrivingSpeed { get; set; }

        public Electronics(string Name, int Price, int BatteryCapacity, int DrivingSpeed) : base(Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.DrivingSpeed = DrivingSpeed;
        }
    }
}
