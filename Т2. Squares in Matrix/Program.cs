using System;
using System.Linq;

namespace Т2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0], input[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            int maxRow = 0;
            int maxCol = 0;

            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;

                    if (IsIndexValid(matrix, row + 2, col + 2))
                    {
                        for (int i = row; i <= row + 2; i++)
                        {
                            for (int j = col; j <= col + 2; j++)
                            {
                                currentSum += matrix[i, j];
                            }
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;

                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public static bool IsIndexValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
