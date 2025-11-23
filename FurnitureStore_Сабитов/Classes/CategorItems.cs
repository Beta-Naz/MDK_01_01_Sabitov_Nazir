using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore_Сабитов.Classes
{
    public class CategorItems
    {
        public string Name { get; set; }
        public string src { get; set; }
        public string Type { get; set; }
        public CategorItems(string name, string src, string type)
        {
            Name = name;
            this.src = src;
            Type = type;
        }
    }
}
