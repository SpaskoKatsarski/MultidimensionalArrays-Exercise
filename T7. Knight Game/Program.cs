using System;
using System.Linq;

namespace T7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = rowInfo[j];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int maxRow = 0;
                int maxCol = 0;

                int maxAttacks = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (board[row, col] == '0')
                        {
                            continue;
                        }

                        //upLeft
                        //upRight
                        if (IsIndexValid(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIndexValid(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        //leftUp
                        //leftDown
                        if (IsIndexValid(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIndexValid(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        //downLeft
                        //downRight
                        if (IsIndexValid(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIndexValid(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        //rightUp
                        //rightDown
                        if (IsIndexValid(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIndexValid(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[maxRow, maxCol] = '0';
                    knightsRemoved++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        public static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
