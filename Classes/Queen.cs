using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess_Сабитов2.Classes
{
    public class Queen : Chess_Figures
    {
        public static int chet = 0;
        public static int chet1 = 0;
        public Queen(int x, int y, bool isBlack)
        {
            X = x;
            Y = y;
            Black = isBlack;
            TypeFigure = "Queen";

            ChoosingFigure(
                "pack://application:,,,/Images/Queen (Black).png",
                "pack://application:,,,/Images/Queen.png",
                "pack://application:,,,/Images/Queen (Select).png"
            );
        }
        public override void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            Chess_Figures targetAttaka = MainWindow.init.ListChessFigures.Find(x => x.Select);

            if (targetAttaka != null && targetAttaka != this)
            {
                if (targetAttaka.TypeFigure == "Pawn") 
                {
                    if ((targetAttaka.Black && !Black && Y - 1 == targetAttaka.Y && (X == targetAttaka.X - 1 || X == targetAttaka.X + 1)) ||
                    (!targetAttaka.Black && Black && Y + 1 == targetAttaka.Y && (X == targetAttaka.X - 1 || X == targetAttaka.X + 1)))
                    {
                        MainWindow.init.gameBoard.Children.Remove(Figure);
                        MainWindow.init.ListChessFigures.Remove(this);
                        Grid.SetColumn(targetAttaka.Figure, X);
                        Grid.SetRow(targetAttaka.Figure, Y);

                        targetAttaka.X = X;
                        targetAttaka.Y = Y;
                        SwitchTurn();
                        targetAttaka.ResetSelect();
                    }
                    else
                    {
                        targetAttaka.ResetSelect();
                        ResetSelect();
                    }
                    ResetAllHighlights();
                    return;
                }
            }

            Chess_Figures targetFigure = MainWindow.init.ListChessFigures.Find(x => x.Select);
            if (targetFigure != null && targetFigure.TypeFigure == "Queen")
            {
                ResetValidMovesForQueen();
                bool isThereAttack = false;
                for (int i = 0; i < ValidAttackToX.Count; i++)
                {
                    if (ValidAttackToX[i] == targetFigure.X && ValidAttackToY[i] == targetFigure.Y)
                    {
                        isThereAttack = true;
                        break;
                    }
                }
                if (isThereAttack)
                {
                    MainWindow.init.gameBoard.Children.Remove(Figure);
                    MainWindow.init.ListChessFigures.Remove(this);
                    Grid.SetColumn(targetFigure.Figure, X);
                    Grid.SetRow(targetFigure.Figure, Y);

                    targetFigure.X = X;
                    targetFigure.Y = Y;
                    SwitchTurn();
                    targetFigure.ResetSelect();
                }
                else
                {
                    targetFigure.ResetSelect();
                    if (!Select)
                    {
                        ResetAllHighlights();
                    }
                }
                ResetAllHighlights();
                return;
            }
            HighlightPossibleMovesToQueen();
            OnSelect(this);
            ResetSelect();
        }

        public override void Transform(int selectX, int selectY)
        {
            ResetValidMovesForQueen();
            bool isThereMove = false;
            for(int i = 0; i < ValidMoveToX.Count; i ++)
            {
                if(ValidMoveToX[i] == selectX && ValidMoveToY[i] == selectY)
                {
                    isThereMove = true;
                    break;
                }
            }
            if (isThereMove)
            {
                    SwitchTurn();
                    Grid.SetColumn(Figure, selectX);
                    Grid.SetRow(Figure, selectY);
                    this.X = selectX;
                    this.Y = selectY;
            }
            ResetAllHighlights();
            ResetSelect();
        }
        public void ResetValidMovesForQueen()
        {
            ValidMoveToX.Clear();
            ValidMoveToY.Clear();
            ValidAttackToX.Clear();
            ValidAttackToY.Clear();
            ValidMoveForQueen(-1, 0); //Left
            ValidMoveForQueen(+1, 0); //Right
            ValidMoveForQueen(0, -1); //Up
            ValidMoveForQueen(0, +1); //Down
            ValidMoveForQueen(-1, -1); //Left-Up
            ValidMoveForQueen(-1, +1); //Left-Down
            ValidMoveForQueen(+1, -1); //Right-Up
            ValidMoveForQueen(+1, +1); //Right-Down
        }
        private void ValidMoveForQueen(int ValidX,int ValidY)
        {
            for (int i = 1; i < 8; i++)
            {
                int ValidMovesX = X + i * ValidX;
                int ValidMovesY = Y + i * ValidY;

                if (ValidMovesX < 0 || ValidMovesX > 7 ||
                    ValidMovesY < 0 || ValidMovesY > 7)
                {
                    break;
                }
                Chess_Figures ValidAttackForQueen = MainWindow.init.ListChessFigures.Find
                    (x => x.X == ValidMovesX && x.Y == ValidMovesY);
                if (ValidAttackForQueen != null)
                {
                    if (ValidAttackForQueen.Black != this.Black)
                    {
                        ValidAttackToX.Add(ValidMovesX);
                        ValidAttackToY.Add(ValidMovesY);
                    }
                    break;
                }
                else
                {
                    ValidMoveToX.Add(ValidMovesX);
                    ValidMoveToY.Add(ValidMovesY);
                }
            }
        }
        public void HighlightPossibleMovesToQueen()
        {
            ResetAllHighlights();
            ResetValidMovesForQueen();
            if (Black && ChessTurn || !Black && !ChessTurn)
            {
                return;
            }
            if (ValidMoveToX.Count > 0)
            {
                for(int i = 0; i < ValidMoveToX.Count; i++)
                {
                    if(SearchValidMoves(ValidMoveToX[i], ValidMoveToY[i]))
                    {
                        HighlightTile(ValidMoveToX[i], ValidMoveToY[i], Colors.Green);
                    }
                }
            }
            if(ValidAttackToX.Count > 0)
            {
                for (int i = 0; i < ValidAttackToX.Count; i++)
                {
                    if (SearchAttack(ValidAttackToX[i], ValidAttackToY[i]))
                    {
                        HighlightTile(ValidAttackToX[i], ValidAttackToY[i], Colors.Red);
                    }
                }
            }
        }
    }
}