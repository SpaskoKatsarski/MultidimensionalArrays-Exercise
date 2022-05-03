using System;
using System.Collections.Generic;
using System.Linq;

namespace T8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            int[] bombCoordinates = Console.ReadLine().Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            List<int[]> explodedBombs = new List<int[]>();

            for (int i = 0; i < bombCoordinates.Length; i += 2)
            {
                int bombRow = bombCoordinates[i];
                int bombCol = bombCoordinates[i + 1];

                explodedBombs.Add(new int[] {bombRow, bombCol});

                int bombValue = matrix[bombRow, bombCol];

                if (bombValue <= 0)
                {
                    continue;
                }

                //topLeft
                if (IsIndexInValid(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
                {
                    matrix[bombRow - 1, bombCol - 1] -= bombValue;
                }
                //top
                if (IsIndexInValid(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
                {
                    matrix[bombRow - 1, bombCol] -= bombValue;
                }
                //topRight
                if (IsIndexInValid(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
                {
                    matrix[bombRow - 1, bombCol + 1] -= bombValue;
                }
                //left
                if (IsIndexInValid(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
                {
                    matrix[bombRow, bombCol - 1] -= bombValue;
                }
                //right
                if (IsIndexInValid(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
                {
                    matrix[bombRow, bombCol + 1] -= bombValue;
                }
                //downLeft
                if (IsIndexInValid(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
                {
                    matrix[bombRow + 1, bombCol - 1] -= bombValue;
                }
                //down
                if (IsIndexInValid(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
                {
                    matrix[bombRow + 1, bombCol] -= bombValue;
                }
                //downRight
                if (IsIndexInValid(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
                {
                    matrix[bombRow + 1, bombCol + 1] -= bombValue;
                }

                //TODO: Make the currently exploded bomb value 0.

                matrix[bombRow, bombCol] = 0;
            }

            for (int i = 0; i < explodedBombs.Count; i++)
            {
                matrix[explodedBombs[i][0], explodedBombs[i][1]] = 0;
            }

            int aliveCount = 0;
            int sumOfAliveCells = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCount++;
                        sumOfAliveCells += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> list = new List<int>();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    list.Add(matrix[i, j]);
                }

                Console.WriteLine(string.Join(' ', list));
            }
        }

        static bool IsIndexInValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
