using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Сабитов.Classes
{
    public class English : Human
    {
        private List<Phrase> Phrases { get; set; }
        private int stepAudio;

        private int StepAudio
        {
            get
            {
                return stepAudio;
            }
            set
            {
                stepAudio = value;
                if (stepAudio > Phrases.Count - 1)
                {
                    stepAudio = 0;
                }
            }
        }
        public English(string name, string img) : base(name, img)
        {
            Phrases = AllPhrases();
        }
        public override void Speak(Label Phrase)
        {
            Phrase.Content = Phrases[StepAudio]._Phrase;
            MainWindow.MediaPlayer.Open(new Uri(Phrases[StepAudio].Src));
            MainWindow.MediaPlayer.Play();
            StepAudio++;
        }
        public static List<Phrase> AllPhrases()
        {
            List<Phrase> allPhrases = new List<Phrase>()
            {
                new Phrase("Hello", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Hello.mp3"),
                new Phrase("How are you", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\How are you.mp3"),
                new Phrase("My name is Alena", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\My name is Alena.mp3")
            };
            return allPhrases;
        }
    }
}
