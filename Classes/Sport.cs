using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Сабитов.Classes
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
