using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub_Сабитов.Models
{
    public class PlayerComputer
    {
        public int Id { get; set; } 
        public DateTime StartTimeRent { get; set; }
        public DateTime EndTimeRent { get; set; }
        public string FullName { get; set; }
        public PlayerComputer() { }
        public PlayerComputer(int id, DateTime startTimeRent, DateTime endTimeRent, 
            string fullName)
        {
            Id = id;
            StartTimeRent = startTimeRent;
            EndTimeRent = endTimeRent;
            FullName = fullName;
        }
    }
}
