using System;
using System.Linq;

namespace T9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[n, n];

            int minerRow = 0;
            int minerCol = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = rowInfo[j];

                    if (field[i, j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                }
            }

            int coalFound = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string currCmd = commands[i];

                if (currCmd == "left")
                {
                    if (IsIndexValid(field, minerRow, minerCol - 1))
                    {
                        field[minerRow, minerCol] = '*';

                        minerCol -= 1;

                        if (field[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (field[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            field[minerRow, minerCol] = '*';
                        }
                    }
                }
                else if (currCmd == "right")
                {
                    if (IsIndexValid(field, minerRow, minerCol + 1))
                    {
                        field[minerRow, minerCol] = '*';

                        minerCol += 1;

                        if (field[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (field[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            field[minerRow, minerCol] = '*';
                        }
                    }
                }
                else if (currCmd == "up")
                {
                    if (IsIndexValid(field, minerRow - 1, minerCol))
                    {
                        field[minerRow, minerCol] = '*';

                        minerRow -= 1;

                        if (field[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (field[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            field[minerRow, minerCol] = '*';
                        }
                    }
                }
                else if (currCmd == "down")
                {
                    if (IsIndexValid(field, minerRow + 1, minerCol))
                    {
                        field[minerRow, minerCol] = '*';

                        minerRow += 1;

                        if (field[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (field[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            field[minerRow, minerCol] = '*';
                        }
                    }
                }
            }

            bool hasFoundAllCoal = true;
            int coalsLeft = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 'c')
                    {
                        hasFoundAllCoal = false;
                        coalsLeft++;
                    }
                }
            }

            if (hasFoundAllCoal)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{coalsLeft} coals left. ({minerRow}, {minerCol})");
            }
        }

        public static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
