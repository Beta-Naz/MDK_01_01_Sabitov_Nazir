using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Сабитов.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public override string ToString() => $"{FIO}";
    }
}
