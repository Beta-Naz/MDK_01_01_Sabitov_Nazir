using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Сабитов.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Create {  get; set; }
        public int IdUsers { get; set; }
        public Messages()
        {

        }
        public Messages(string message, DateTime create, int idUsers)
        {
            Message = message;
            Create = create;
            IdUsers = idUsers;
        }
    }
}
