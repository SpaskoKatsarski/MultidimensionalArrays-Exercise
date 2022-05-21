using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            List<int[]> explodedBombsCoordinates = new List<int[]>();

            int[] bombCoordinates = Console.ReadLine()
                .Split(new char[] { ' ', ',' })
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombCoordinates.Length - 1; i++)
            {
                int bombRow = bombCoordinates[i];
                int bombCol = bombCoordinates[i + 1];

                int bombValue = matrix[bombRow, bombCol];

                if (bombValue <= 0)
                {
                    continue;
                }

                explodedBombsCoordinates.Add(new int[] { bombRow, bombCol });

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
            }

            for (int i = 0; i < explodedBombsCoordinates.Count; i++)
            {
                int row = explodedBombsCoordinates[i][0];
                int col = explodedBombsCoordinates[i][1];

                matrix[row, col] = 0;
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsIndexInValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
