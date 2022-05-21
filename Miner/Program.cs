using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            string[] moveCommands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < size; row++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowInfo[col];
                }
            }

            int minerRow = 0;
            int minerCol = 0;

            bool hasFoundTheStart = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;

                        hasFoundTheStart = true;

                        break;
                    }
                }

                if (hasFoundTheStart)
                {
                    break;
                }
            }

            int collectedCoal = 0;
            bool hasEnded = false;

            for (int i = 0; i < moveCommands.Length; i++)
            {
                string command = moveCommands[i];

                if (command == "left" && IsIndexValid(field, minerRow, minerCol - 1))
                {
                    minerCol -= 1;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        hasEnded = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoal++;
                        field[minerRow, minerCol] = '*';
                    }
                }
                else if (command == "right" && IsIndexValid(field, minerRow, minerCol + 1))
                {
                    minerCol += 1;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        hasEnded = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoal++;
                        field[minerRow, minerCol] = '*';
                    }
                }
                else if (command == "up" && IsIndexValid(field, minerRow - 1, minerCol))
                {
                    minerRow -= 1;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        hasEnded = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoal++;
                        field[minerRow, minerCol] = '*';
                    }
                }
                else if (command == "down" && IsIndexValid(field, minerRow + 1, minerCol))
                {
                    minerRow += 1;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        hasEnded = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoal++;
                        field[minerRow, minerCol] = '*';
                    }
                }
            }

            if (hasEnded)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else
            {
                int remainingCoal = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (field[row, col] == 'c')
                        {
                            remainingCoal++;
                        }
                    }
                }

                if (remainingCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                }
                else
                {
                    Console.WriteLine($"{remainingCoal} coals left. ({minerRow}, {minerCol})");
                }
            }
        }

        static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
