namespace PlanimetryLibrary
{



    public class Line
    {
        public Point a { get; }
        public Point b { get; }

        public LineEquation Equation { get; }

        public double Length => Point.DistanceBetweenTwoPoints(a, b);

        public Line(Point a, Point b)
        {
            this.a = a;
            this.b = b;
            this.Equation = new LineEquation();
            //GetEquation(ref this.Equation);

        }

        public bool CalculateSlope(ref LineEquation Equation)
        {
            if ((a.x - b.x) != 0.0)
            {
                Equation.Slope = (b.y - a.y) / (b.x - a.x);
                return true;
            }
            else
            {
                Equation.Slope = 0;
                return false;
            }
        }


        public bool GetEquation(ref LineEquation Equation)
        {
            if (CalculateSlope(ref Equation))
            {
                Equation.A = -Equation.Slope;
                Equation.B = 1;
                Equation.C = (-Equation.Slope * a.x) + a.y;
                return true;
            }
            else
            {
                return false;
            }
        }

    }


    public class LineEquation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Slope { get; set; }
    }





}