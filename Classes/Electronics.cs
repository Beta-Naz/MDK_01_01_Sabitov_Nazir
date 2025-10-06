using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Shop_Сабитов.Classes
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
