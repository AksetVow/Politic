using DataAccess.Mongo;
using Domain.DataAccess;
using Parser;
using System;

namespace ParserService
{
    class Program
    {
        static void Main(string[] args)
        {
            IDeputyRepository repository = new MongoDeputyRepository("deputyDb");

            var parser = new DepytatyParser();
            var result = parser.ParseDeputies();
            foreach (var res in result)
            {
                repository.Add(res);
            }

            Console.WriteLine("Finish deputies parsing");
            Console.ReadLine();
        }
    }
}
