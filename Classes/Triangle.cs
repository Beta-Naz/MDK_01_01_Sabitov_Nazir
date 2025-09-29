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
            if(!ValidTriangle(longA, longB, longC))
            {
                MessageBox.Show("Невозможно построить такой треугольник");
                return new Point[0];
            }
            double S = CalculateArea(longA, longB, longC);
            double R = (longA * longB * longC) / (4 * S);
            Point A = new Point(centreX + R, centreY);
            double angleB = 2 * Math.Asin(longA / (2 * R));
            Point B = new Point(
                centreX + R * Math.Cos(angleB),
                centreY + R * Math.Sin(angleB)
            );
            double angleC = 2 * Math.Asin(longB / (2 * R));
            Point C = new Point(
                centreX + R * Math.Cos(angleC),
                centreY - R * Math.Sin(angleC)
            );
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
