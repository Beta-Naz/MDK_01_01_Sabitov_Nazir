using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сinema_Сабитов.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public int CountHall { get; set; }
        public int CountPlace { get; set; }
        public Cinema() { }
        public Cinema(int id, int countHall, int countPlace)
        {
            Id = id;
            CountHall = countHall;
            CountPlace = countPlace;
        }
    }
}
