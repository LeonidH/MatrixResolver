using System;
using System.Collections;
using System.Diagnostics;

namespace LeanidHubar
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            foreach (char[,] matrix in GetTestData())
            {
                DateTime start = DateTime.Now;
                var count = LeanidHubar.SolveMatrix(matrix);
                DateTime end = DateTime.Now;
                
                TimeSpan ts = (end - start);
                Console.WriteLine($"Paths: {count} - Duration, ms: {ts.TotalMilliseconds}");
                //Console.ReadKey();
            }
        }

        static IEnumerable GetTestData()
        {
            yield return new char[5, 5]
            {
                {'A', 'B', 'C', Char.MinValue, 'E'},
                {Char.MinValue, 'G', 'H', 'I', 'J'},
                {'K', 'L', 'M', 'N', 'O'},
                {'P', 'Q', 'R', 'S', 'T'},
                {'U', 'V', Char.MinValue, Char.MinValue, 'Y'}
            };
        }
    }
}