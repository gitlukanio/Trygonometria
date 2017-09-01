using System;

namespace TrygonometryLibrary
{
    public class Triangle
    {
        public Point A { get; }

        public Point B { get; }

        public Point C { get; }

        public Sector SectorAB => new Sector(A, B);

        public Sector SectorAC => new Sector(A, C);

        public Sector SectorBC => new Sector(B, C);

        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public override string ToString()
        {
            return "Trójkąt - A(" + A.ToString() + "), B(" + B.ToString() + "), C(" + C.ToString() + ")\n" +
                   "AB:(" + SectorAB.ToString() + ")\n" +
                   "AC:("+SectorAC.ToString()+")\n" +
                   "CB:("+SectorBC.ToString()+")\n" +
                   "Pole:("+this.GetArea()+"), " + 
                   "Obwód:("+this.GetCircumference()+")";

        }


        public double GetCircumference()
        {
            return SectorAB.Lenght + SectorBC.Lenght + SectorAC.Lenght;
        }

        public double GetArea()
        {
            Line hLine = Line.GetPerpendicularLine(SectorBC.Line, A);
            //Console.WriteLine("hline:{0}", hLine.ToString());
            Point hPoint = Line.PointOfIntersect(SectorBC.Line, hLine);
            //Console.WriteLine("hPoint:{0}", hPoint.ToString());
            return 0.5 * SectorBC.Lenght * Point.DistanceBetweenTwoPoints(A, hPoint);
        }
    }
}