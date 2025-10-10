using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Batlle_Сабитов.Classes
{
    public class Turn
    {
        public string WhoseMove;
        public Turn(string move)
        {
            WhoseMove = move;
        }
        public static List<Turn> Turns;

        public static Dictionary<string, Brush> ColorsToTurn;
        public static void ResetColorTurns()
        {
            ColorsToTurn = new Dictionary<string, Brush>
            {
                ["Player"] = Brushes.Green,
                ["First"] = Brushes.Yellow,
                ["Second"] = Brushes.Orange,
                ["Third"] = Brushes.Red,
                ["Fourth"] = Brushes.DarkRed,
            };
        }

        public static void ResetTurns(int countMonsters)
        {
            Turns = new List<Turn>();
            List<string> nomberMonster = new List<string>();
            nomberMonster.Add("First");
            if (countMonsters >= 2)
            {
                nomberMonster.Add("Second");
                if (countMonsters >= 4)
                {
                    nomberMonster.Add("Third");
                    nomberMonster.Add("Fourth");
                }
            }
            double countTurnPlayer = 1 + (Player.Dexterity / 20);
            int i;
            for (i = 0; i < countTurnPlayer; i++)
            {
                Turns.Add(new Turn("Player"));
            }
            for (i = 0; i < nomberMonster.Count; i++)
            {
                Turns.Add(new Turn($"{nomberMonster[i]}"));
                if(Player.Dexterity > 60)
                {
                    Turns.Add(new Turn("Player"));
                }
            }
        }
        public static void RemoveTurn(string nameTurn)
        {
            Turn poisk = Turns.Find(t => t.WhoseMove == nameTurn);
            if(poisk != null)
            {
                Turns.Remove(poisk);
            }
        }
    }
}
