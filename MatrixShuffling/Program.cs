using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                int[] rowInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //check if the command is valid:
                if (cmdArgs[0] == "swap" && cmdArgs.Length == 5)
                {
                    //command is valid

                    //check if the coordinates are valid
                    //swap 0 0 1 1
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);

                    if (row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1)
                        && row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        //everything is valid, we can start swapping the valuse in the matrix:
                        int firstValue = matrix[row1, col1];
                        int secondValue = matrix[row2, col2];

                        matrix[row1, col1] = secondValue;
                        matrix[row2, col2] = firstValue;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        //invalid command; we should print the appropriate message:
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    //invalid command; we should print the appropriate message:
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
