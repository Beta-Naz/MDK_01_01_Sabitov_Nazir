namespace Shop_Сабитов.Models
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int DrivingSpeed { get; set; }

        public Electronics(int id, string Name, int Price, int BatteryCapacity, int DrivingSpeed) : base(id, Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.DrivingSpeed = DrivingSpeed;
        }
    }
}
