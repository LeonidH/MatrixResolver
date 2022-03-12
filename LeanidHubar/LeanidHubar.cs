using System;
using System.Collections.Generic;
using System.Linq;

namespace LeanidHubar
{
    public class LeanidHubar
    {
        private static readonly int _maxMoves = 8;

        private static readonly char[] Vowels = new[] {'A', 'E', 'I', 'O', 'U', 'Y'};

        private static readonly int[,] Moves =
        {
            {2, 1},
            {-2, 1},
            {2, -1},
            {-2, -1},
            {1, 2},
            {1, -2},
            {-1, 2},
            {-1, -2}
        };

        public static long SolveMatrix()
        {
            var matrix = new char[5, 5]
            {
                {'A', 'B', 'C', Char.MinValue, 'E'},
                {Char.MinValue, 'G', 'H', 'I', 'J'},
                {'K', 'L', 'M', 'N', 'O'},
                {'P', 'Q', 'R', 'S', 'T'},
                {'U', 'V', Char.MinValue, Char.MinValue, 'Y'}
            };
            
            return SolveMatrix(matrix);
        }

        public static long SolveMatrix(char[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var colums = matrix.GetLength(1);

            var count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    var path = new List<char>();
                    if (BuildPath(i, j, path, 0, matrix))
                    {
                        if (path.Count(c => Vowels.Contains(Char.ToUpper(c))) <= 2)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static bool BuildPath(int row, int column, List<char> path, int moveNum, char[,] matrix)
        {
            if (moveNum >= _maxMoves) return true;
            
            moveNum++;

            if (matrix[row, column] != Char.MinValue)
            {
                path.Add(matrix[row, column]);
            }
            else return false;

            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                var nextRow = row + Moves[i, 0];
                var nextColumn = column + Moves[i, 1];
                if (
                    nextRow >= 0 && nextRow < matrix.GetLength(0)
                                 && nextColumn >= 0 && nextColumn < matrix.GetLength(1)
                )
                {
                    if (BuildPath(nextRow, nextColumn, path, moveNum, matrix))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}