namespace TrygonometryLibrary
{
    public class Sector
    {
        public Point StartPoint { get; }

        public Point EndPoint { get; }

        public Line Line
        {
            get
            {
                return new Line(StartPoint, EndPoint);
            }
        }

        public double Lenght
        {
            get
            {
                return Point.DistanceBetweenTwoPoints(StartPoint, EndPoint);
            }
        }

        public Sector(Point p1, Point p2)
        {
            this.StartPoint = p1;
            this.EndPoint = p2;
        }




    }
}