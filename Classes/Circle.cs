using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Geometria_Сабитов.Classes
{
    public class Circle : GeometricFigure
    {
        public double Radius;
        public Circle(double centreX, double centreY, double radius) : base(centreX, centreY)
        {
            Radius = radius / 2;
        }
        public double Diameter
        {
            get
            {
                return Radius * 2;
            }
        }
    }
}
