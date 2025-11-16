using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Сабитов.Classes
{
    public class SummaryPrice
    {
        public int Price = 0;
        public int Count = 0;
        public int TypeSize;
        public int Id;
        public SummaryPrice(int price, int count, int typeSize, int id)
        {
            Price = price;
            Count = count;
            TypeSize = typeSize;
            Id = id;
        }
    }
}
