using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    public class Items
    {
        public int Price { get; set; }
        public string Images { get; set; }
        public string Name { get; set; }
        public bool СanUse { get; set; }
        public Items(int price, string images, string name, bool canUse)
        {
            Price = price;
            Images = images;
            Name = name;
            СanUse = canUse;
        }
    }
}
