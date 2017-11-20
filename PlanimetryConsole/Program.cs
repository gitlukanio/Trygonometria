using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanimetryLibrary;

namespace PlanimetryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Line l1 = new Line(new Point(-7, 3), new Point(9, 3));
            Line l2 = new Line(new Point(-5, 5), new Point(5, -5));
            Line l3 = new Line(new Point(-6, -2), new Point(7, -2));
            Line l4 = new Line(new Point(3, -7), new Point(3, 6));
            Line l5 = new Line(new Point(-1, -6), new Point(-1, 4));
            Line l6 = new Line(new Point(-4, -4), new Point(5, 5));

            List<Line> listaLini = new List<Line>();

            listaLini.Add(l1);
            listaLini.Add(l2);
            listaLini.Add(l3);
            listaLini.Add(l4);
            listaLini.Add(l5);
            listaLini.Add(l6);

            //Sprawdzamy(listaLini);

            Triangle tr = new Triangle(new Point(3, 1), new Point(7, 1), new Point(3, 4));

            Console.WriteLine(tr.ToString());

            List<Point> punkty = new List<Point>()
            {
                new Point(6,3),
                new Point(4,5),
                new Point(1,6),
                new Point(-1,6),
                new Point(-5,5),
                new Point(-6,2),
                new Point(-6,-1),
                new Point(-5,-4),
                new Point(-3,-6),
                new Point(-1,-7),
                new Point(1,-7),
                new Point(3, -6),
                new Point(5,-4),
                new Point(7,-2)
            };

            SprawdzamyTrojkaty(punkty);

        }

        private static void SprawdzamyTrojkaty(List<Point> punkty)
        {
            Console.WriteLine("Sprawdzamy trójkąty:");

            foreach (var point in punkty)
            {
                Triangle tr = new Triangle(new Point(1, 1), new Point(7, 1), point);

                Console.WriteLine(
                    "Trójkąt {0} Suma kątów {1} Powierzchnia {2}",
                    point.ToString(),
                    tr.AngleAlfa + tr.AngleBeta + tr.AngleGamma,
                    tr.Area);


            }


        }
    }
}
