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
            for (var i = 0; i < 2; i++)
            {
                finder.SetStartingPage("http://en.wikipedia.org/wiki/Special:Random");
                results.Add(finder.Find());
                Console.WriteLine($"{i} link was found");
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
    