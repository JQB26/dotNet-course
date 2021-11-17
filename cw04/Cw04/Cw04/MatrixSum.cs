using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Cw04
{
    public class MatrixSum
    {
        public List<List<int>> Matrix { get; }
        public MatrixSum(int n, int m)
        {
            Random random = new Random();
            Matrix = Enumerable.Range(0, n).Select(i =>
                Enumerable.Repeat(random.Next(), m).ToList()).ToList();
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix.Max(l => l.Count); j++)
                {
                    Console.Write(Matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}