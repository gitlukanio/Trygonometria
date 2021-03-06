﻿using System;
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
        // public double LengthAB_C => SideC.Length; //Point.DistanceBetweenTwoPoints(a, b); // c
        // public double LengthBC_A => SideA.GetLength(); //Point.DistanceBetweenTwoPoints(b, c); // a
        // public double LengthCA_B => SideB.GetLength(); //Point.DistanceBetweenTwoPoints(c, a); // b

        public Line SideC { get; }
        public Line SideA { get; }
        public Line SideB { get; }


        /// <summary>
        /// Kwadraty dłógości boków - potrzebne do wyliczenia kątów
        /// </summary>
        private double AA => Math.Pow(SideA.Length, 2f);
        private double BB => Math.Pow(SideB.Length, 2f);
        private double CC => Math.Pow(SideC.Length, 2f);

        /// <summary>
        /// Kąty zawarte w trójkącie
        /// </summary>
        public double AngleAlfa => (Math.Acos((BB + CC - AA) / (2 * SideB.Length * SideC.Length))) * 180 / Math.PI;
        public double AngleBeta => (Math.Acos((AA + CC - BB) / (2 * SideA.Length * SideC.Length))) * 180 / Math.PI;
        public double AngleGamma => (Math.Acos((AA + BB - CC) / (2 * SideA.Length * SideB.Length))) * 180 / Math.PI;

        /// <summary>
        /// Obwód trójkąta
        /// </summary>
        public double Circumference => SideC.Length + SideA.Length + SideB.Length;

        /// <summary>
        /// Połowa obwodu trójkąta
        /// </summary>
        public double p => (Circumference / 2f);

        /// <summary>
        /// Powierzchnia trójkąta
        /// </summary>
        public double Area => Math.Sqrt(p * (p - SideC.Length) * (p - SideA.Length) * (p - SideB.Length) * 1f);

        /// <summary>
        /// Promień okręgu wpisanego w trójkąt
        /// </summary>
        public double r => Area / p;

        /// <summary>
        /// Promień okręgu opisanego na trójkąt
        /// </summary>
        public double R => (SideC.Length * SideA.Length * SideB.Length / (4f * Area));

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

            SideA = new Line(b, c);
            SideB = new Line(c, a);
            SideC = new Line(a, b);

            float tolerance = 0.0001f;
            if (Math.Abs(AngleAlfa - 90) < tolerance || Math.Abs(AngleBeta - 90) < tolerance || Math.Abs(AngleGamma - 90) < tolerance)
                IsRectangular = true;
        }

        /// <summary>
        /// Zwraca punkt ciężkości trójkąta.
        /// </summary>
        /// <returns></returns>
        public Point GetCentroid()
        {
            var x = (a.x + b.x + c.x) / 3f;
            var y = (a.y + b.y + c.y) / 3f;
            return new Point(x, y);
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
            sb.AppendLine($"Bok A:{SideA.Length:f3}");
            sb.AppendLine($"Bok B:{SideB.Length:f3}");
            sb.AppendLine($"Bok C:{SideC.Length:f3}");
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