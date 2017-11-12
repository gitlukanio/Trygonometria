using System;
using System.Security.Policy;

namespace TrygonometryLibrary
{
    public class Line : IFigure
    {

        public double A { get; }
        public double B { get; }
        private bool CzyPionowa { get; }
        private bool CzyPozioma { get; }
        private double Y { get; }
        private double X { get; }

        public Line(Point p1, Point p2)
        {
            this.A = (p2.Y - p1.Y) / (p2.X - p1.X);
            this.B = p1.Y - A * p1.X;
            if (p1.X == p2.X)
            {
                CzyPionowa = true;
                X = p1.X;
            }
            if (p1.Y == p2.Y)
            {
                CzyPozioma = true;
                Y = p1.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Line(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        public double Get_Y(double x)
        {
            if (CzyPozioma)
                return Y;
            else
                return A * x + B;
        }

        public double Get_X(double y)
        {
            if (CzyPionowa)
                return X;
            else
                return (y - B) / A;
        }

        public bool IfPointBelongToLine(Point p)
        {
            if (p.Y == A * p.X + B)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return "Linia: Y = " + A + " X + " + B;
        }

        /// <summary>
        /// Zwraca Punkt przecięcia dwóch prostych, jeżeli istnieje oczywiście.
        /// </summary>
        /// <param name="prosta 1"></param>
        /// <param name="prosta 2"></param>
        /// <returns></returns>
        public static Point PointOfIntersect(Line l1, Line l2)
        {
            if (l1.A == l2.A)
                return null; // Linie są do siebie równoległe lub sa takie same.
            else
            {
                var x = (l2.B - l1.B) / (l1.A - l2.A);
                var y = l1.A * x + l1.B;
                return new Point(x, y);
            }
        }

        public static Line GetPerpendicularLine(Line l1, Point p1) // zwraca linie prostopadłą przechodzącą przez punkt p1.
        {
            double A = -1 / l1.A;
            double B = p1.Y - A * p1.X;
            return new Line(A, B);
        }



    }
}