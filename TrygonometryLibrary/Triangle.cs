using System;

namespace TrygonometryLibrary
{
    public class Triangle
    {
        public Point A { get; }

        public Point B { get; }

        public Point C { get; }
        //=======================================================
        //1
        public Sector SectorAB
        {
            get
            {
                return new Sector(A, B);
            }
        }

        //2
        public Sector SectorAC()
        {
            return new Sector(A, C);
        }

        //3
        public Sector SectorBC => new Sector(B, C);
        //========================================================


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
            Point hPoint = Line.PointOfIntersect(SectorBC.Line, hLine);
            return 0.5 * SectorBC.Lenght * Point.DistanceBetweenTwoPoints(A, hPoint);
        }
    }
}