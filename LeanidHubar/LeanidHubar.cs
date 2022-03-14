using System;
using System.Collections.Generic;
using System.Linq;

namespace LeanidHubar
{
    public class LeanidHubar
    {
        private static readonly int _maxMoves = 8;

        private static readonly HashSet<char> Vowels = new(){'A', 'E', 'I', 'O', 'U', 'Y'};

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
            var rowsCount = matrix.GetLength(0);
            var columnsCount = matrix.GetLength(1);

            var count = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    count += GetUniqPathsCount(i, j, matrix);
                }
            }

            return count;
        }

        private static int GetUniqPathsCount(int row, int column, char[,] matrix, int count = 0, int vowelsCount = 0, int pathLength = 0)
        {
            if (matrix[row, column] != Char.MinValue)
            {
                ++pathLength;
                
                if (Vowels.Contains(matrix[row, column]))
                {
                    ++vowelsCount;
                    
                    if (vowelsCount > 2)
                    {
                        return count;
                    }
                }
                
                if (pathLength >= _maxMoves)
                {
                    return ++count;
                }
            }
            else return count;

            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                var nextRow = row + Moves[i, 0];
                var nextColumn = column + Moves[i, 1];
                if (
                    nextRow >= 0 && nextRow < matrix.GetLength(0)
                                 && nextColumn >= 0 && nextColumn < matrix.GetLength(1)
                )
                {
                    count = GetUniqPathsCount(nextRow, nextColumn, matrix, count, vowelsCount, pathLength);
                }
            }

            return count;
        }
    }
}