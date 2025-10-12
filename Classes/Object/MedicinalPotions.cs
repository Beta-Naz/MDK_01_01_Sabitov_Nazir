using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    public class MedicinalPotions : Items
    {
        public double Heal;
        public MedicinalPotions(int price, string images, string name, bool canUse, double heal) : base(price, images, name, canUse)
        {
            Heal = heal;
        }
    }
}
