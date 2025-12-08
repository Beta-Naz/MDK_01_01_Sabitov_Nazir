using System;

namespace Documents_Сабитов.Model
{
    public class DocumentContext
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string IdDocument { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Direction { get; set; }

    }
}
