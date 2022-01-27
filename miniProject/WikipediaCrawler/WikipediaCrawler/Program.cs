using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikipediaCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = new List<int>();

            var finder = new Finder("https://en.wikipedia.org/wiki/Elizabeth_II");
            for (var i = 0; i < 100; i++)
            {
                finder.SetStartingPage("http://en.wikipedia.org/wiki/Special:Random");
                var res = finder.Find();
                results.Add(res);
                Console.WriteLine($"{i+1} link was found: {res}");
            }
            
            Console.WriteLine("Final results are:");
            foreach (var result in results)
            {
                Console.Write($"{result}, ");
            }

            Console.ReadKey();
        }
    }
}
    