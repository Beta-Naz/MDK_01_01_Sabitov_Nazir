using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Сабитов.Classes
{
    public class Deutsch : Human
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
        public Deutsch(string name, string img) : base(name, img)
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
                new Phrase("Hallo", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Hallo.mp3"),
                new Phrase("Wie geht es", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Wie geht es.mp3"),
                new Phrase("Mein Name ist Sasha", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Mein Name ist Sasha.mp3")
            };
            return allPhrases;
        }
    }
}
