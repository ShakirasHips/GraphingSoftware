using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial poly1 = new Polynomial("2x^2+3x^1-5x^0");
            Polynomial poly2 = new Polynomial("1x^1+2x^0");

            Fraction<Polynomial> val = new Fraction<Polynomial>(poly1, poly2);
            
            Console.WriteLine(val.ToString());
            Console.ReadKey();
    }
    }
}
