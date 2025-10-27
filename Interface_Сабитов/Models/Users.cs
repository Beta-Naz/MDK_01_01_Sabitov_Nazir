using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Сабитов.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public Users() { }
        public Users(int id, string fIO)
        {
            Id = id;
            FIO = fIO;
        }
    }
}
