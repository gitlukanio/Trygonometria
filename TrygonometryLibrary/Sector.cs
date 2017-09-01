namespace TrygonometryLibrary
{
    public class Sector
    {
        public Point StartPoint { get; }

        public Point EndPoint { get; }

        public Line Line => new Line(StartPoint, EndPoint);

        public double Lenght => Point.DistanceBetweenTwoPoints(StartPoint, EndPoint);

        public Sector(Point p1, Point p2)
        {
            this.StartPoint = p1;
            this.EndPoint = p2;
        }

        public override string ToString()
        {
            return "SP:("+ StartPoint.ToString() +"), EP:("+EndPoint.ToString()+"), Line:("+Line.ToString()+"), DŁ:("+ Lenght.ToString() +")";
        }
    }
}