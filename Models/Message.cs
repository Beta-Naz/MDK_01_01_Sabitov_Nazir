namespace ChatStudents_Sabitov.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public string ContentMessage { get; set; }
        public DateTime TimeSending { get; set; }
        public Message(int userFrom, int userTo, string contentMessage)
        {
            UserFrom = userFrom;
            UserTo = userTo;
            ContentMessage = contentMessage;
            TimeSending = DateTime.Now;
        }
    }
}
