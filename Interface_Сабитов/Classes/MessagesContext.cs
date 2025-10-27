using Interface_Сабитов.Interfaces;
using Interface_Сабитов.Models;
using System;
using System.Collections.Generic;

namespace Interface_Сабитов.Classes
{
    public class MessagesContext : Messages, IMessages
    {
        public static List<Messages> AllMessages;
        public MessagesContext() => All(out AllMessages);
        public MessagesContext(string message, DateTime create, int idUsers) : base(message, create, idUsers) 
        {
        }
        public void All(out List<Messages> Messages) => Messages = new List<Messages>();
        public void Delete() => AllMessages.Remove(this);

        public void Save(bool Update = false)
        {
            if(!Update)
            {
                AllMessages.Add(this);
            }
        }
        public void Edit(string text)
        {
            int a = AllMessages.FindIndex(x => x == this);
            AllMessages[a].Message = text;
        }
    }
}
