using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;

namespace Chess_Сабитов2.Classes
{
    public abstract class Chess_Figures
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Select, Black;
        public string TypeFigure;
        public List<string> ImagesFigure = new List<string>();
        public List<int> ValidMoveToX = new List<int>();
        public List<int> ValidMoveToY = new List<int>();
        public List<int> ValidAttackToX = new List<int>();
        public List<int> ValidAttackToY = new List<int>();
        public static bool ChessTurn { get; set; } = true;
        public Grid Figure { get; set; }

        public abstract void SelectFigure(object sender, MouseButtonEventArgs e);
        public abstract void Transform(int targetX, int targetY);

        public void ResetSelect()
        {
            if (ImagesFigure == null)
            {
                return;
            }
            if (Select)
            {
                if (Black)
                {
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(ImagesFigure[0])));
                }
                else
                {
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(ImagesFigure[1])));
                }
                Select = false;
            }
            else
            {
                if (Black && !ChessTurn)
                {
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(ImagesFigure[2])));
                    Select = true;
                }
                else if (!Black && ChessTurn)
                {
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(ImagesFigure[2])));
                    Select = true;
                }
            }
        }
        public void ChoosingFigure(string blackFigure, string whiteFigure, string selectedFigure)
        {
            ImagesFigure.Clear();
            ImagesFigure.Add(blackFigure);
            ImagesFigure.Add(whiteFigure);
            ImagesFigure.Add(selectedFigure);
        }

        public static void SwitchTurn()
        {
            ChessTurn = !ChessTurn;
            Victory();
        }

        public void OnSelect(Chess_Figures selectedFigure)
        {
            foreach (Chess_Figures figure in MainWindow.init.ListChessFigures)
            {
                if (figure != selectedFigure && figure.Select)
                {
                    ResetSelect();
                }
            }
        }
        public bool SearchAttack(int x, int y)
        {
            Chess_Figures searchAttackFigure = MainWindow.init.ListChessFigures.Find(s => s.X == x && s.Y == y);
            if (searchAttackFigure != null && searchAttackFigure.Black != Black)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SearchValidMoves(int x, int y)
        {
            Chess_Figures searchValidMoves = MainWindow.init.ListChessFigures.Find(s => s.X == x && s.Y == y);
            if (searchValidMoves == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void HighlightTile(int x, int y, Color color)
        {
            // Создаем хранилище для сохранения ориг цвета
            var tile = MainWindow.init.gameBoard.Children
                .OfType<Grid>()
                .FirstOrDefault(t => Grid.GetColumn(t) == x && Grid.GetRow(t) == y);

            if (tile != null)
            {
                // Сохраняем оригинальный цвет чтобы потом восстановить
                tile.Tag = tile.Background;
                tile.Background = new SolidColorBrush(color);
            }
        }

        public static void ResetAllHighlights()
        {
            foreach (var tile in MainWindow.init.gameBoard.Children.OfType<Grid>())
            {
                if (tile.Tag != null)
                {
                    tile.Background = (Brush)tile.Tag;
                    tile.Tag = null;
                }
            }
        }
        public static void Victory()
        {
            
            bool hasBlack = MainWindow.init.ListChessFigures.Any(x => x.Black);
            bool hasWhite = MainWindow.init.ListChessFigures.Any(x => !x.Black);

            if (!hasBlack)
            {
                ResetAllHighlights();
                MessageBox.Show("Победа за белыми");
                MainWindow.init.Close();
            }
            else if (!hasWhite)
            {
                ResetAllHighlights();
                MessageBox.Show("Победа за черными");
                MainWindow.init.Close();
            }
        }
    }
}
 