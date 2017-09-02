using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrygonometryLibrary;

namespace Trygonometria_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point p1 = new Point(, );

            Line l1 = new Line(new Point(1.0, 2.0), new Point(6.0, 4.0) );
            Console.WriteLine("A: " + l1.A);
            Console.WriteLine("B: " + l1.B);
            
            Console.WriteLine(l1.ToString());

            Console.WriteLine("Dla X=1 Y=" + l1.Get_Y(1.0));
            Console.WriteLine("Dla Y=4 X=" + l1.Get_X(4.0));

            if (l1.IfPointBelongToLine(new Point(4, 3)))
            {
                Console.WriteLine("Punkt (3,4) lezy na lini" );
            }
            else
            {
                Console.WriteLine("Punkt (3,4) nie lezy na lini");
            }

            Console.WriteLine("======================================");

            Line l2 = new Line(new Point(1.0, 1.0), new Point(6.0, 3.0)); // równoległa
            Line l3 = new Line(new Point(2.0, 4.0), new Point(5.0, 2.0)); // przecięcie w punkcie 3,5 3

            Console.WriteLine("Linia 1: " + l1.ToString());
            Console.WriteLine("Linia 2: " + l3.ToString());

            Point p3 = Line.PointOfIntersect(l1, l3);

            if (p3 != null)
            {
                Console.WriteLine("Punk przeciecia: X={0} Y={1}", p3.X, p3.Y);
            }
            else
            {
                Console.WriteLine("Dwie linie się nie przecinają!!!");
            }


            Console.WriteLine("======================================");

            Console.WriteLine("=====Generujemy linie prostopadłą=====");

            Line l5 = new Line(new Point(1.0, 2.0), new Point(6.0, 4.0));

            Line l6 = Line.GetPerpendicularLine(l5,new Point(6, 4));

            if (Line.PointOfIntersect(l5, l6) != null)
            {
                Console.WriteLine("Punkt przecięcia: {0}\n\n", Line.PointOfIntersect(l5, l6).ToString());
            }


            Console.WriteLine("=====Odległośc punktów od siebie=====");
            Point p1 = new Point(1,1);
            Point p2 = new Point(2.5, 0.5);
            Console.WriteLine("Punkt1 = {0}, Punkt2 = {1}", p1.ToString(), p2.ToString());
            Console.WriteLine("Odległość = {0}\n\n", Point.DistanceBetweenTwoPoints(p1, p2));

            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("Teraz trójkąt");
            Point tra = new Point(1, 1);
            Point trb = new Point(2, 2.5);
            Point trc = new Point(4, 1);
            Triangle tr = new Triangle(tra, trb, trc);

            Console.WriteLine("Obwód trójkąta: {0}", tr.GetCircumference());
            Console.WriteLine("Pole trójkąta: {0}\n\n", tr.GetArea());
            //onsole.WriteLine("CB:{0}", tr.SectorBC.Line.ToString());

            Console.WriteLine(tr.ToString());

            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("Teraz koło");
            Circle k = new Circle(tra, 2);

            Console.WriteLine(k.ToString());



            //Console.ReadKey();

        }
    }
}
