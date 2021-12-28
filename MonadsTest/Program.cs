using LanguageExt;
using System;

namespace MonadsTest
{
    class Program
    {
        static Func<Either<Exception, int>> division = () =>
        {
            var x = 0;
            x = 10 / x;
            return x;
        };


        static void Main(string[] args)
        {
            string toTitle(string r) => $"this is the result {r.ToUpper()}";

            var dispayMessage = new Try<int>(division)
              .SelectMany(result => new Try<int>(() => result / int.Parse(Console.ReadLine())))
              .Select(r => r.ToString())
              .Select(toTitle)
              .Result
              .Match(r => r, e => e.Message);
            Console.WriteLine("Hello World!");

        }


    }
}
