namespace PlanimetryLibrary
{
    public class Line
    {
        public Point a { get; set; }
        public Point b { get; set; }
        public double Length => Point.DistanceBetweenTwoPoints(a, b);
        public Line(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }
    }
}