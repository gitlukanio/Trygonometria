namespace TrygonometryLibrary
{
    public class Triangle
    {
        public Point A { get; }

        public Point B { get; }

        public Point C { get; }

        public Sector SectorAB => new Sector(A, B);

        public Sector SectorAc => new Sector(A, C);

        public Sector SectorBC => new Sector(B, C);

        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }


    }
}