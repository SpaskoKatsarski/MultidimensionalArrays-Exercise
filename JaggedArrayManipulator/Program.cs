using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int i = 0; i < jagged.Length; i++)
            {
                double[] rowInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jagged[i] = rowInfo;
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    jagged[row] = jagged[row].Select(el => el * 2).ToArray();
                    jagged[row + 1] = jagged[row + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    jagged[row] = jagged[row].Select(el => el / 2).ToArray();
                    jagged[row + 1] = jagged[row + 1].Select(el => el / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Add")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    double value = double.Parse(cmdArgs[3]);

                    if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                    {
                        //valid
                        jagged[row][col] += value;
                    }
                }
                else if (cmdArgs[0] == "Subtract")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    double value = double.Parse(cmdArgs[3]);

                    if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                    {
                        //valid
                        jagged[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(' ', jagged[row]));
            }
        }
    }
}
