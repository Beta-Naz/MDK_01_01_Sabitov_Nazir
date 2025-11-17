using System.Collections.Generic;

namespace PrintManagementSystem_Сабитов.Classes
{
    public class Format
    {
        public int id {  get; set; }
        public string format { get; set; }
        public string description { get; set; }
        public Format(int id, string format, string description)
        {
            this.id = id;
            this.format = format;
            this.description = description;
        }
        public static List<Format> AllFormats()
        {
            return new List<Format>()
            {
                new Format(1,"A4",""),
                new Format(1,"A3",""),
                new Format(1,"A2",""),
                new Format(1,"A1",""),
            };
        }
    }
}
