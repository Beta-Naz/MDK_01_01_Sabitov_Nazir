using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Chess_Сабитов2.Classes
{
    public class Pawn : Chess_Figures
    {
        public Pawn(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;
            TypeFigure = "Pawn";

            ChoosingFigure(
               "pack://application:,,,/Images/Pawn (black).png",
               "pack://application:,,,/Images/Pawn.png",
               "pack://application:,,,/Images/Pawn (select).png"
           );
        }
        public override void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            Chess_Figures targetAttaka = MainWindow.init.ListChessFigures.Find(x => x.Select);
            if (targetAttaka != null && targetAttaka != this)
            {
                if (targetAttaka.TypeFigure == "Queen")
                {
                    Queen queen = targetAttaka as Queen;
                    queen.ResetValidMovesForQueen();
                    bool isThereAttack = false;
                    for (int i = 0; i < queen.ValidAttackToX.Count; i++)
                    {
                        if (queen.ValidAttackToX[i] == this.X && queen.ValidAttackToY[i] == this.Y)
                        {
                            isThereAttack = true;
                            break;
                        }
                    }
                    if (isThereAttack)
                    {
                        MainWindow.init.gameBoard.Children.Remove(Figure);
                        MainWindow.init.ListChessFigures.Remove(this);
                        Grid.SetColumn(targetAttaka.Figure, X);
                        Grid.SetRow(targetAttaka.Figure, Y);

                        targetAttaka.X = X;
                        targetAttaka.Y = Y;
                        SwitchTurn();
                        queen.ResetSelect();
                        ResetAllHighlights();
                        return;
                    }
                    else
                    {
                        HighlightPossibleMoves();
                        targetAttaka.ResetSelect();
                        ResetSelect();
                        return;
                    }
                }
            }
            Chess_Figures targetFigure = MainWindow.init.ListChessFigures.Find(x => x.Select);

            if (targetFigure != null && targetFigure.TypeFigure == "Pawn")
            {
                if ((targetFigure.Black && !Black && Y - 1 == targetFigure.Y && (X == targetFigure.X - 1 || X == targetFigure.X + 1)) ||
                (!targetFigure.Black && Black && Y + 1 == targetFigure.Y && (X == targetFigure.X - 1 || X == targetFigure.X + 1)))
                {
                    MainWindow.init.gameBoard.Children.Remove(Figure);
                    MainWindow.init.ListChessFigures.Remove(this);
                    Grid.SetColumn(targetFigure.Figure, X);
                    Grid.SetRow(targetFigure.Figure, Y);

                    targetFigure.X = X;
                    targetFigure.Y = Y;
                    SwitchTurn();
                    targetFigure.ResetSelect();
                    ResetAllHighlights();
                }
                else
                {
                    ResetAllHighlights();
                    HighlightPossibleMoves();
                    if (this != targetFigure)
                    {
                        ResetSelect();
                    }
                    targetFigure.ResetSelect();
                    if (!Select)
                    {
                        ResetAllHighlights();
                    }
                }
                return;
            }
            ResetSelect();
            OnSelect(this);
            HighlightPossibleMoves();
        }
        public override void Transform(int X, int Y)
        {
            ResetAllHighlights();
            if (X != this.X)
            {
                ResetSelect();
                return;
            }
            if (Black && ((this.Y == 1 && this.Y + 2 == Y && SearchValidMoves(this.X, this.Y + 1)) || this.Y + 1 == Y) ||
                !Black && ((this.Y == 6 && this.Y - 2 == Y && SearchValidMoves(this.X, this.Y - 1)) || this.Y - 1 == Y))
            {
                SwitchTurn();
                Grid.SetColumn(Figure, X);
                Grid.SetRow(Figure, Y);
                this.X = X;
                this.Y = Y;
                Transformation();
            }
            ResetSelect();
        }

        private void HighlightPossibleMoves()
        {
            ResetAllHighlights();
            if (Black)
            {
                if (Y + 1 <= 7 && !ChessTurn)
                {
                    if (SearchValidMoves(X, Y + 1))
                    {
                        HighlightTile(X, Y + 1, Colors.Green);
                    }
                }
                if (Y == 1 && Y + 2 <= 7 && !ChessTurn)
                {
                    if (SearchValidMoves(X, Y + 2) && SearchValidMoves(X, Y + 1))
                    {
                        HighlightTile(X, Y + 2, Colors.Green);
                    }
                }
                if (X - 1 >= 0 && Y + 1 <= 7 && !ChessTurn)
                {
                    if (SearchAttack(X - 1, Y + 1))
                    {
                        HighlightTile(X - 1, Y + 1, Colors.Red);
                    }
                }
                if (X + 1 <= 7 && Y + 1 <= 7 && !ChessTurn)
                {
                    if (SearchAttack(X + 1, Y + 1))
                    {
                        HighlightTile(X + 1, Y + 1, Colors.Red);
                    }
                }
            }
            else
            {
                if (Y - 1 >= 0 && ChessTurn)
                {
                    if (SearchValidMoves(X, Y - 1))
                    {
                        HighlightTile(X, Y - 1, Colors.Green);
                    }
                }
                if (Y == 6 && Y - 2 >= 0 && ChessTurn)
                {
                    if (SearchValidMoves(X, Y - 2) && SearchValidMoves(X, Y - 1))
                    {
                        HighlightTile(X, Y - 2, Colors.Green);
                    }
                }
                if (X - 1 >= 0 && Y - 1 >= 0 && ChessTurn)
                {
                    if (SearchAttack(X - 1, Y - 1))
                    {
                        HighlightTile(X - 1, Y - 1, Colors.Red);
                    }
                }
                if (X + 1 <= 7 && Y - 1 >= 0 && ChessTurn)
                {
                    if (SearchAttack(X + 1, Y - 1))
                    {
                        HighlightTile(X + 1, Y - 1, Colors.Red);
                    }
                }
            }
        }
        private void Transformation()
        {
            if ((Y == 7 || Y == 0) && TypeFigure == "Pawn")
            {
                MainWindow.init.gameBoard.Children.Remove(Figure);
                MainWindow.init.ListChessFigures.Remove(this);
                MainWindow.init.ListChessFigures.Add(new Classes.Queen(X, Y, Black));
                Chess_Figures NewQueen = MainWindow.init.ListChessFigures.Find(x => x.X == X && x.Y == Y);
                if (NewQueen != null)
                {
                    NewQueen.Figure = new Grid()
                    {
                        Width = 50,
                        Height = 50
                    };
                    NewQueen.Figure.Background = new ImageBrush(new BitmapImage(new Uri(NewQueen.Black ? NewQueen.ImagesFigure[0] : NewQueen.ImagesFigure[1])));
                    Grid.SetColumn(NewQueen.Figure, NewQueen.X);
                    Grid.SetRow(NewQueen.Figure, NewQueen.Y);
                    NewQueen.Figure.MouseDown += NewQueen.SelectFigure;
                    MainWindow.init.gameBoard.Children.Add(NewQueen.Figure);
                    ;

                }
            }
        }
    }
}