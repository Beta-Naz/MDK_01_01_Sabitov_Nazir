using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Сабитов.Classes
{
    public abstract class Human
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public Human(string name, string img)
        {
            Name = name;
            Img = img;
        }
        public abstract void Speak(Label Phrase);
    }
}
