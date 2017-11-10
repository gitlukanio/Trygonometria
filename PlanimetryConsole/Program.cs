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
            Line3 l1 = new Line3(new Point(3, 1), new Point(3, 4));
            Console.WriteLine("\nLine pionowa:\n{0}", l1.ToString());
            Console.WriteLine("=============================\n");

            Line3 l2 = new Line3(new Point(1, 3), new Point(4, 3));
            Console.WriteLine("\nLine pozioma:\n{0}", l2.ToString());
            Console.WriteLine("=============================\n");

            Console.WriteLine(" sprawdzamy punkty");

            Line3 l3 = new Line3(new Point(1, 1), new Point(3, 3));
            Line3 l4 = new Line3(new Point(3, 3), new Point(5, 1));

            Point intersectPoint = Line3.PointOfIntersect(l3, l4);

            if (intersectPoint != null)
            {
                Console.WriteLine(intersectPoint.ToString());

            }
            else
            {
                Console.WriteLine("Nie ma punktu!!!!");
            }


        }
    }
}
