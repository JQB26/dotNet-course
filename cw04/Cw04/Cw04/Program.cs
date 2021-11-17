using System;

namespace Cw04
{
    class Program
    {
        static void Main(string[] args)
        {
            // SquareGenerator sq = new SquareGenerator(Convert.ToInt32(Console.ReadLine()));
            // sq.PrintResults();

            MatrixSum ms = new MatrixSum(4, 5);
            ms.PrintMatrix();
        }
    }
}
