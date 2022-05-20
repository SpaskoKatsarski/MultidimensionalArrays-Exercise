using System;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte size = byte.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowInfo[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int attacks = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsIndexValid(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                attacks++;
                            }

                            if (IsIndexValid(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                attacks++;
                            }
                        }

                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                removedKnights++;
            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsIndexValid(char[,] board, int index, int col)
        {
            return index >= 0 && index < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
