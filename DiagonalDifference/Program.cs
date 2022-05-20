using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            int primeSum = 0;
            int secondarySum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        primeSum += matrix[i, j];
                    }


                    if (i + j == size - 1)
                    {
                        secondarySum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primeSum - secondarySum));
        }
    }
}
