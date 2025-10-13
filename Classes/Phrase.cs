using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Сабитов.Classes
{
    public class Phrase
    {
        public string _Phrase { get; set; }
        public string Src { get; set; }
        public Phrase(string phrase, string src)
        {
            _Phrase = phrase;
            Src = src;
        }
    }
}
