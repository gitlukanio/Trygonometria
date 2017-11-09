using System;

namespace PlanimetryLibrary
{
    public class Point
    {
        public float x { get; set; }
        public float y { get; set; }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        public static double DistanceBetweenTwoPoints(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        }

        public override string ToString()
        {
            return $"X={x} Y={y}";

        }
    }
}