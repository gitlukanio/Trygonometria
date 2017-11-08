using System;
using System.Security.AccessControl;
using System.Text;

namespace PlanimetryLibrary
{
    public class Triangle
    {
        /// <summary>
        /// Wierzchołki trójkąta
        /// </summary>
        public Point a { get; }
        public Point b { get; }
        public Point c { get; }

        /// <summary>
        /// Długości poszczególnych boków trójkąta
        /// </summary>
        public double LengthAB_c => Point.DistanceBetweenTwoPoints(a, b); // c
        public double LengthBC_a => Point.DistanceBetweenTwoPoints(b, c); // a
        public double LengthCA_b => Point.DistanceBetweenTwoPoints(c, a); // b

        /// <summary>
        /// Kwadraty dłógości boków - potrzebne do wyliczenia katów
        /// </summary>
        private double Length_aa => Math.Pow(LengthBC_a, 2f);
        private double Length_bb => Math.Pow(LengthCA_b, 2f);
        private double Length_cc => Math.Pow(LengthAB_c, 2f);
        
        /// <summary>
        /// Kąty zawarte w trójkącie
        /// </summary>
        public double AngleAlfa => (Math.Acos((Length_bb + Length_cc - Length_aa)/(2*LengthCA_b*LengthAB_c))) * 180 / Math.PI;
        public double AngleBeta => (Math.Acos((Length_aa + Length_cc - Length_bb)/(2*LengthBC_a*LengthAB_c))) * 180 / Math.PI;
        public double AngleGamma => (Math.Acos((Length_aa + Length_bb - Length_cc)/(2*LengthBC_a*LengthCA_b))) * 180 / Math.PI;
        
        /// <summary>
        /// Obwód trójkąta
        /// </summary>
        public double Circumference => LengthAB_c + LengthBC_a + LengthCA_b;

        /// <summary>
        /// Połowa obwodu trójkąta
        /// </summary>
        public double p => (Circumference / 2f);

        /// <summary>
        /// Powierzchnia trójkąta
        /// </summary>
        public double Area => Math.Sqrt(p * (p-LengthAB_c) * (p-LengthBC_a) * (p-LengthCA_b) * 1f );

        /// <summary>
        /// Promień okręgu wpisanego w trójkąt
        /// </summary>
        public double r => Area / p;

        /// <summary>
        /// Promień okręgu opisanego na trójkąt
        /// </summary>
        public double R => (LengthAB_c * LengthBC_a * LengthCA_b / (4f * Area));

        /// <summary>
        /// Czy trójkąt jest prostokątny
        /// </summary>
        public bool IsRectangular { get; }
        
        /// <summary>
        /// Konstruktor podstawowy
        /// </summary>
        /// <param name="a">Punkt wierzchołka A</param>
        /// <param name="b">Punkt wierzchołka B</param>
        /// <param name="c">Punkt wierzchołka C</param>
        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            float tolerance = 0.0001f;
            if (Math.Abs(AngleAlfa - 90) < tolerance || Math.Abs(AngleBeta - 90) < tolerance || Math.Abs(AngleGamma - 90) < tolerance)
                IsRectangular = true;
        }


        /// <summary>
        /// Wypisuje parametry trójkąta
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine()
            sb.AppendLine("Długości Boków:");
            sb.AppendLine($"Bok A:{LengthBC_a:f3}");
            sb.AppendLine($"Bok B:{LengthCA_b:f3}");
            sb.AppendLine($"Bok C:{LengthAB_c:f3}");
            sb.AppendLine("================================");
            sb.AppendLine($"Obwód trójkata: {Circumference:f3}");
            sb.AppendLine($"Połowa obwodu: {p:f3}");
            sb.AppendLine($"Powierzchnia trójkata: {Area:f3}");
            sb.AppendLine("================================");
            sb.AppendLine($"Promień okręgu opisanego: {R:f3}");
            sb.AppendLine($"Promień okręgu wpisanego: {r:f3}");
            sb.AppendLine("================================");
            sb.AppendLine(" * * * Nowe Kąty: * * ");
            sb.AppendLine($"Kąt Alfa:{AngleAlfa:f3}");
            sb.AppendLine($"Kąt Beta:{AngleBeta:f3}");
            sb.AppendLine($"Kąt Gamma:{AngleGamma:f3}");
            sb.AppendLine($"Suma kątów: {(AngleAlfa + AngleBeta + AngleGamma):f3}");
            if (IsRectangular)
            {
                sb.AppendLine("Trójkąt jest prostokątny!!!");
            }
            else
            {
                sb.AppendLine("Trójkąt * NIE * jest prostokątny!!!");
            }

            return sb.ToString();
        }
    }
}