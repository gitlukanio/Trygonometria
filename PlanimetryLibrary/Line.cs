using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace PlanimetryLibrary
{
    public class Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Length { get; set; }

        private Point PA;
        private Point PB;

        public Point MidPoint;

        public Line(Point p1, Point p2)
        {
            // postać ogólna równania prostej przechodzącej przez dwa punkty
            this.A = p1.y - p2.y;
            this.B = p2.x - p1.x;
            this.C = p1.x * p2.y - p2.x * p1.y; //this.C = (p1.x - p2.x) * p1.y + (p2.y - p1.y) * p1.x;
            PA = p1;
            PB = p2;
            this.Length = Point.DistanceBetweenTwoPoints(PA, PB);
            MidPoint = new Point((PA.x + PB.x) / 2, (PA.y + PB.y) / 2);

        }

        /// <summary>
        /// Zwraca długość odcinka, pomiędzy dwoma punktami.
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            return Point.DistanceBetweenTwoPoints(PA, PB);
        }

        /// <summary>
        /// Zwaraca punkt przecięcia dwóch linii, jeżeli istnieje
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static Point PointOfIntersect(Line l1, Line l2)
        {
            if (l1.A * l2.B != l2.A * l1.B)
            {
                var x = (l1.B * l2.C - l2.B * l1.C) / (l1.B * l2.A - l2.B * l1.A) * -1;
                var y = (l1.A * l2.C - l2.A * l1.C) / (l1.A * l2.B - l2.A * l1.B) * -1;
                return new Point((float)x, (float)y);

            }
            else
            {
                // Brak punktu przecięcia. Linie są równoległe lub takie same.
                return null;
            }



        }


        //public double GetY(double x)
        //{

        //}

        //public double GetX(double y)
        //{

        //}


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Punkt A: {PA.ToString()}");
            sb.AppendLine($"Punkt B: {PB.ToString()}");
            sb.AppendLine($"A: {A} B: {B} C: {C}");
            if (B == 0)
                sb.AppendLine("Prosta jest równoległa do osi Y");
            if (B != 0 && A == 0)
                sb.AppendLine("Prosta jest równoległa do osi X");

            return sb.ToString();
        }
    }





}