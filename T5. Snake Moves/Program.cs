using System;
using System.Collections.Generic;
using System.Linq;

namespace T5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[length[0], length[1]];

            string input = Console.ReadLine();

            Queue<char> snake = new Queue<char>();

            for (int i = 0; i < input.Length; i++)
            {
                snake.Enqueue(input[i]);
            }

            bool leftToRight = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (leftToRight)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        char currChar = snake.Dequeue();
                        matrix[i, j] = currChar;
                        snake.Enqueue(currChar);
                    }

                    leftToRight = false;
                }
                else if (!leftToRight)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currChar = snake.Dequeue();
                        matrix[i, col] = currChar;
                        snake.Enqueue(currChar);
                    }

                    leftToRight = true;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
