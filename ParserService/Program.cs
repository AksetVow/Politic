using Parser;
using System;
using System.IO;
using System.Linq;

namespace ParserService
{


    class Car
    {
        private Wheel[] _wheels;

    }

    class Wheel {

    } 
     



    class Program
    {
        static void Main(string[] args)
        {
            var parser = new DepytatyParser();
            var result = parser.ParseDeputies();
            using (var sw = new StreamWriter("output.txt", false))
            {
                foreach (var res in result)
                {
                    sw.WriteLine($"{res.FullName} - {string.Join(", ", res.ParlamentNumbers.ToArray())}");
                }
            }

            Console.WriteLine("Finish deputies parsing");
            Console.ReadLine();
        }
    }
}
