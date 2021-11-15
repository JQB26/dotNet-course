using System;
using System.Collections.Generic;
using System.Linq;

namespace Cw04
{
    public class SquareGenerator
    {
        public IEnumerable<int> Squares { get; }

        public SquareGenerator(int n)
        {
            Squares = Enumerable.Range(1, n)
                .Where(x => (x != 5) && (x != 9) && ((x % 2 == 1) || (x % 7 == 0)))
                .Select(x => x * x);
        }

        public void PrintResults()
        {
            Console.WriteLine("Sum of the elements: " + Squares.Sum());
            Console.WriteLine("Number of elements: " + Squares.Count());
            Console.WriteLine("First element: " + Squares.First());
            Console.WriteLine("Last element: " + Squares.Last());
            Console.WriteLine("The third element: " + Squares.ToList()[3]);
        }

    }
}