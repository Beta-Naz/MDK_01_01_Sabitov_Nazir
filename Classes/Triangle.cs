using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Geometria_Сабитов.Classes
{
    public class Triangle : GeometricFigure
    {
        public double LongA;
        public double LongB;
        public double LongC;

        public Triangle(double centreX, double centreY, double longA, double longB, double longC) : base(centreX, centreY)
        {
            LongA = longA;
            LongB = longB;
            LongC = longC;
        }

        public static Point[] BuildTriangle(double centreX, double centreY, double longA, double longB, double longC)
        {
            if (!ValidTriangle(longA, longB, longC))
            {
                MessageBox.Show("Невозможно построить такой треугольник");
                return new Point[0];
            }

            Point A = new Point(0, 0);
            Point B = new Point(longC, 0);

            double angleA = Math.Acos((longB * longB + longC * longC - longA * longA) / (2 * longB * longC));
            double Cx = longB * Math.Cos(angleA);
            double Cy = longB * Math.Sin(angleA);
            Point C = new Point(Cx, Cy);

            Point centroid = new Point(
                (A.X + B.X + C.X) / 3,
                (A.Y + B.Y + C.Y) / 3
            );

            double offsetX = centreX - centroid.X;
            double offsetY = centreY - centroid.Y;
            A = new Point(A.X + offsetX, A.Y + offsetY);
            B = new Point(B.X + offsetX, B.Y + offsetY);
            C = new Point(C.X + offsetX, C.Y + offsetY);

            return new Point[] { A, B, C };
        }

        private static bool ValidTriangle(double longA, double longB, double longC)
        {
            return longA + longB > longC && longA + longC > longB && longB + longC > longA;
        }

        private static double CalculateArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}