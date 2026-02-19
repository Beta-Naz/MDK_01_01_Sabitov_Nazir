using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub_Сабитов.Models
{
    public class CompiterClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartTimeWork { get; set; }
        public DateTime EndTimeWork { get; set; }
        public CompiterClub() { }
        public CompiterClub(int id, string name, string address, DateTime startTimeWork, DateTime endTimeWork)
        {
            Id = id;
            Name = name;
            Address = address;
            StartTimeWork = startTimeWork;
            EndTimeWork = endTimeWork;
        }
    }
}
