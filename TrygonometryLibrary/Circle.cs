using System;

namespace TrygonometryLibrary
{
    public class Circle
    {
        public Point MidPoint { get; }

        public double R { get; }

        public double Area => Math.PI * Math.Pow(R, 2);

        public double Circumference => 2 * Math.PI * R;

        public override string ToString()
        {
            return "Koło:( MidPoint("+MidPoint.ToString()+"), Radius:("+R+"))";
        }

        public Circle(Point p1, double r)
        {
            this.MidPoint = p1;
            this.R = r;
        }
    }
}