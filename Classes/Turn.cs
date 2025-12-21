using Batlle_Сабитов.Elements;
using System.Collections.Generic;
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
        public static List<Turn> Turns = new List<Turn>();

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
            Turns.Clear();
            List<string> nomberMonster = new List<string>() { "First" };
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
            if (poisk != null)
            {
                Turns.Remove(poisk);

                int removedIndex = Turns.IndexOf(poisk);
                if (removedIndex != -1 && Batlle.turn > removedIndex)
                {
                    Batlle.turn--;
                }

                if (Batlle.turn >= Turns.Count)
                {
                    Batlle.turn = 0;
                }

                var turnBack = new[]
                {
                    Batlle.init.TurnOne,
                    Batlle.init.TurnTwo,
                    Batlle.init.TurnThree,
                    Batlle.init.TurnFour,
                    Batlle.init.TurnFive,
                };

                for (int i = 0; i < turnBack.Length; i++)
                {
                    if (i < Turns.Count)
                    {
                        int turnIndex = (Batlle.turn + i) % Turns.Count;
                        turnBack[i].Background = ColorsToTurn[Turns[turnIndex].WhoseMove];
                    }
                }
                if (turnBack[0].Background == ColorsToTurn["Player"])
                {
                    Player.ValidAttack = true;
                    Batlle.DisposeTimer();
                }
            }
        }
    }
}
