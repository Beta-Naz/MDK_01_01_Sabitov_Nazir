using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сinema_Сабитов.Models
{
    public class Poster
    { 
        public int Id { get; set; }
        public string IdCinema { get; set; }
        public string Film { get; set; }
        public TimeSpan TimeSession;
        public decimal PriceSession;
        public decimal PriceTicket;
        public Poster() { }
        public Poster(int id, string idCinema, string film, TimeSpan timeSession, decimal priceSession, decimal priceTicket)
        {
            Id = id;
            IdCinema = idCinema;
            Film = film;
            TimeSession = timeSession;
            PriceSession = priceSession;
            PriceTicket = priceTicket;
        }
    }
}
