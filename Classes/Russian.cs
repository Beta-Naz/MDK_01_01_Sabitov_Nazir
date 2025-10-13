using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Сабитов.Classes
{
    public class Russian : Human
    {
        private List<Phrase> Phrases {  get; set; }
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
        public Russian(string name, string img) : base(name, img)
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
                new Phrase("Привет", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Привет.mp3"),
                new Phrase("Как дела", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Как_дела.mp3"),
                new Phrase("Меня зовут Александр", @"C:\Users\student-a502\Desktop\Human_Сабитов\Voices\Меня_зовут_Александр.mp3")
            };
            return allPhrases;
        }
    }
}
