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
            Console.WriteLine("Sprawdzamy trójkąt:");
            Triangle trojkat = new Triangle(new Point(3,1), new Point(6,8), new Point(7,1));
            Console.WriteLine(trojkat.ToString());
            Console.WriteLine("====================================================");
            

        }
    }
}
