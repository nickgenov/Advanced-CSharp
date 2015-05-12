using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatrixShuffling
{
    static void Main()
    {
        //parse input
        int rowCount = int.Parse(Console.ReadLine());
        int colCount = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rowCount, colCount];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        //perform swaps
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] commands = input.Split(' ');
            if (commands[0] != "swap" && commands.Length != 5)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                int x1 = int.Parse(commands[1]);
                int y1 = int.Parse(commands[2]);
                int x2 = int.Parse(commands[3]);
                int y2 = int.Parse(commands[4]);

                if (x1 < matrix.GetLength(0) && x2 < matrix.GetLength(0) &&
                    y1 < matrix.GetLength(1) && y2 < matrix.GetLength(1))
                {
                    string swap = matrix[x2, y2];
                    matrix[x2, y2] = matrix[x1, y1];
                    matrix[x1, y1] = swap;

                    //print swapped matrix
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }                
            }
            input = Console.ReadLine();
        }
    }
    public static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}