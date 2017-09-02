using System;

namespace TrygonometryLibrary
{
    public class Circle
    {
        public Point MidPoint { get; }

        public double R { get; }

        public double Area { get => Math.PI * Math.Pow(R, 2); }

        public double Circumference{ get => 2 * Math.PI * R; }

        public override string ToString()
        {
            return "Koło:()"
        }
    }
}