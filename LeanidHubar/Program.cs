using System;
using System.Collections;

namespace LeanidHubar
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (char[,] matrix in GetTestData())
            {
                LeanidHubar.SolveMatrix(matrix);
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