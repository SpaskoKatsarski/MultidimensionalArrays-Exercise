using System;
using System.Linq;

namespace T1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            int leftToRightSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                leftToRightSum += matrix[i, i];
            }

            int rightToLeftSum = 0;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                rightToLeftSum += matrix[i, matrix.GetLength(1) - i - 1];
            }

            Console.WriteLine(Math.Abs(leftToRightSum - rightToLeftSum));
        }
    }
}
