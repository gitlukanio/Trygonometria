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
            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("Test");
            
            Point a = new Point(3,1);
            Point b = new Point(3,4);
            Point c = new Point(7,1);
            //Point c = new Point(10, 1);

            Triangle tr = new Triangle(a,b,c);


            //Sector s = new Sector(new Point(3,4), new Point(7,1) );
            //Console.WriteLine("Sektor długość: {0}", s.Lenght);

            Console.WriteLine("Czy jest prostokątny: {0}", tr.IsTriangleRectangular());
            Console.WriteLine("Promien wpisanego: {0}", tr.PromienOkreguWpisanego());

            double r = tr.PromienOkreguWpisanego();
            Point pac = new Point(tr.A.X+r*2, tr.SectorAC.Line.Get_Y(tr.A.X + r*2));
            Line LPC = Line.GetPerpendicularLine(tr.SectorAC.Line, pac);
            //Console.WriteLine("Punkt PAC:{0}", pac.ToString());
            Point pab = new Point(tr.SectorAB.Line.Get_X(tr.A.Y + r * 2),tr.A.Y+r*2);
            Line LPB = Line.GetPerpendicularLine(tr.SectorAB.Line, pab);

            Point paaaaa = Line.PointOfIntersect(LPC, LPB);
            Console.WriteLine("Punkt PAAAA{0}", paaaaa.ToString());
            Console.WriteLine("Promien opisanego na : {0}", tr.PromienOkreguOpisanego());
            Console.WriteLine("Point of gravity: {0}", tr.GetCenterOfGravity());

            

            //Console.ReadKey();

        }
    }
}
