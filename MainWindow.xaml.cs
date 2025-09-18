using Chess_Сабитов2.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess_Сабитов2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;

        public List<Classes.Chess_Figures> ListChessFigures = new List<Classes.Chess_Figures>();
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            ListChessFigures.Add(new Classes.Pawn(0, 6, false));
            ListChessFigures.Add(new Classes.Pawn(1, 6, false));
            ListChessFigures.Add(new Classes.Pawn(2, 6, false));
            ListChessFigures.Add(new Classes.Pawn(3, 6, false));
            ListChessFigures.Add(new Classes.Pawn(4, 6, false));
            ListChessFigures.Add(new Classes.Pawn(5, 6, false));
            ListChessFigures.Add(new Classes.Pawn(6, 6, false));
            ListChessFigures.Add(new Classes.Pawn(7, 6, false));

            ListChessFigures.Add(new Classes.Pawn(0, 1, true));
            ListChessFigures.Add(new Classes.Pawn(1, 1, true));
            ListChessFigures.Add(new Classes.Pawn(2, 1, true));
            ListChessFigures.Add(new Classes.Pawn(3, 1, true));
            ListChessFigures.Add(new Classes.Pawn(4, 1, true));
            ListChessFigures.Add(new Classes.Pawn(5, 1, true));
            ListChessFigures.Add(new Classes.Pawn(6, 1, true));
            ListChessFigures.Add(new Classes.Pawn(7, 1, true));

            ListChessFigures.Add(new Classes.Queen(3, 7, false));
            ListChessFigures.Add(new Classes.Queen(3, 0, true));
            CreateFigure();
        }
        public void CreateFigure()
        {
            foreach (Classes.Chess_Figures Chess_Figures in ListChessFigures)
            {
                Chess_Figures.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                Chess_Figures.Figure.Background = new ImageBrush(new BitmapImage(new Uri(Chess_Figures.Black ? Chess_Figures.ImagesFigure[0] : Chess_Figures.ImagesFigure[1])));
                Grid.SetColumn(Chess_Figures.Figure, Chess_Figures.X);
                Grid.SetRow(Chess_Figures.Figure, Chess_Figures.Y);
                Chess_Figures.Figure.MouseDown += Chess_Figures.SelectFigure;
                gameBoard.Children.Add(Chess_Figures.Figure);
            }
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);
            Classes.Chess_Figures SelectFigure = ListChessFigures.Find(x => x.Select == true);
            if (SelectFigure != null)
            {
                SelectFigure.Transform(X, Y);
            }
        }
        public void Crik()
        {
            MessageBox.Show($"Да может атакавать");
        }
    }
}