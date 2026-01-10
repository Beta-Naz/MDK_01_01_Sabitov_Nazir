using System;

namespace Airlines_Сабитов.Models
{
    public class TicketClass
    {
        public int Id { get; set; }
        public string price { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_way { get; set; }
        public TicketClass(int Id, string from, string to, string price, DateTime time_start, DateTime time_way)
        {
            this.Id = Id;
            this.price = price;
            this.from = from;
            this.to = to;
            this.time_start = time_start;
            this.time_way = time_way;
        }
    }
}
