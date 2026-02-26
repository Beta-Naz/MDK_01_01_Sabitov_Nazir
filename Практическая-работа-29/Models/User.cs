namespace Практическая_работа_29.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FIO { get; set; }
        public DateTime RentStart { get; set; }
        public int Duration { get; set; }
        public int IdClub {  get; set; }
    }
}
