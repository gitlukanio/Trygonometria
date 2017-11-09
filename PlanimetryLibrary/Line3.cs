using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace PlanimetryLibrary
{
    public class Line3
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double C2 { get; set; }

        private Point PA;
        private Point PB;

        public Point MidPoint;

        public Line3(Point p1, Point p2)
        {
            // postać ogólna równania prostej przechodzącej przez dwa punkty
            this.A = p1.y - p2.y;
            this.B = p2.x - p1.x;
            this.C = (p1.x - p2.x) * p1.y + (p2.y - p1.y) * p1.x;
            this.C2 = p1.x * p2.y - p2.x * p1.y;

            PA = p1;
            PB = p2;

            MidPoint = new Point((PA.x + PB.x) / 2, (PA.y + PB.y) / 2);

        }

        public double GetY(double x)
        {

        }

        public double GetX(double y)
        {

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Punkt A: {PA.ToString()}");
            sb.AppendLine($"Punkt B: {PB.ToString()}");
            sb.AppendLine($"A: {A} B: {B} C: {C} C2: {C2}");
            if (B == 0)
                sb.AppendLine("Prosta jest równoległa do osi Y");
            if (B != 0 && A == 0)
                sb.AppendLine("Prosta jest równoległa do osi X");

            return sb.ToString();
        }
    }





}