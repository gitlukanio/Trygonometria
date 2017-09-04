using System;

namespace TrygonometryLibrary
{
    public class Triangle : IFigure
    {
        public Point A { get; }

        public Point B { get; }

        public Point C { get; }
        ////=======================================================
        ////1
        //public Sector SectorAB
        //{
        //    get
        //    {
        //        return new Sector(A, B);
        //    }
        //}

        ////2
        //public Sector SectorAC()
        //{
        //    return new Sector(A, C);
        //}

        ////3
        //public Sector SectorBC => new Sector(B, C);
        ////========================================================

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
            Point hPoint = Line.PointOfIntersect(SectorBC.Line, hLine);
            return 0.5 * SectorBC.Lenght * Point.DistanceBetweenTwoPoints(A, hPoint);
        }

        public Point GetCenterOfGravity()
        {
            double x = (this.A.X + this.B.X + this.C.X) / 3;
            double y = (this.A.Y + this.B.Y + this.C.Y) / 3;
            return new Point(x, y);
        }

        public bool IsTriangleRectangular()
        {
            double AB = Math.Pow(SectorAB.Lenght,2);
            double AC = Math.Pow(SectorAC.Lenght,2);
            double BC = Math.Pow(SectorBC.Lenght,2);

            if (AB+AC==BC || AC+BC==AB || AB+BC==AC)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public double PromienOkreguWpisanego()
        {
            return 2 * this.GetArea() / (SectorAC.Lenght + SectorAB.Lenght + SectorBC.Lenght);
        }

        public double PromienOkreguOpisanego()
        {
            return SectorAB.Lenght * SectorAC.Lenght * SectorBC.Lenght / 4 * this.PromienOkreguWpisanego()* (GetCircumference()/2);
        }


    }
}