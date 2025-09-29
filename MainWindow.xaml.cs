using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geometria_Сабитов.Classes;

namespace Geometria_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectFigure = 0;
        string[] mas = new string[] { "Треугольник", "Круг" }; 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SelectFigure_Click(object sender, RoutedEventArgs e)
        {
            selectFigure++;
            if(selectFigure >= mas.Length)
            {
                selectFigure = 0;
            }
            SelectFigure.Content = mas[selectFigure];
            if(selectFigure == 0)
            {
                X.Text = "Центральный X";
                Y.Text = "Центральный Y";
                A.Text = "Длина строны A";
                B.Text = "Длина строны B";
                C.Text = "Длина строны C";
            }
            else if(selectFigure == 1)
            {
                X.Text = "Центральный X";
                Y.Text = "Центральный Y";
                A.Text = "Радиус";
                B.Text = "";
                C.Text = "";
            }
        }
        private void CreateFigure_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectFigure == 0)
                {
                    DrawTriangle(double.Parse(X.Text), double.Parse(Y.Text), double.Parse(A.Text), double.Parse(B.Text), double.Parse(C.Text));
                }
                else if(selectFigure == 1)
                {
                    DrawCircle(double.Parse(X.Text), double.Parse(Y.Text), double.Parse(A.Text));
                }
            }
            catch
            {
                X.Text = "";
                Y.Text = "";
                A.Text = "";
                B.Text = "";
                C.Text = "";
            }
        }
        private void DrawTriangle(double centerA, double centerB, double a, double b, double c)
        {
            Point[] vertices = Triangle.BuildTriangle(centerA, centerB, a, b, c);
            Polygon triangle = new Polygon
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.LightBlue
            };

            foreach (Point vertex in vertices)
            {
                triangle.Points.Add(vertex);
            }

            Canvas.SetLeft(triangle, 0);
            Canvas.SetTop(triangle, 0);
            canvas.Children.Add(triangle);
        }
        public void DrawCircle(double centreX, double centreY, double radius)
        {
            Ellipse circle = new Ellipse()
            {
                Width = radius,
                Height = radius,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.Red
            };

            Canvas.SetLeft(circle, centreX - radius);
            Canvas.SetTop(circle, centreY - radius);
            canvas.Children.Add(circle);
        }
        private void RandomCreateFigure_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            if (selectFigure == 0)
            {
                X.Text = $"{rd.Next(0, 400)}";
                Y.Text = $"{rd.Next(0, 400)}";
                A.Text = $"{rd.Next(150, 200)}";
                B.Text = $"{rd.Next(150, 200)}";
                C.Text = $"{rd.Next(150, 200)}";
            }
            else if (selectFigure == 1)
            {
                X.Text = $"{rd.Next(0, 400)}";
                Y.Text = $"{rd.Next(0, 400)}";
                A.Text = $"{rd.Next(0, 200)}";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }
    }
}
