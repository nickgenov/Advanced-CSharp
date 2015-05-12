using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FillTheMatrixPatternA
{
    static void Main()
    {
        //parse matrix size
        int n = int.Parse(Console.ReadLine());

        //fill the matrix
        int[,] matrix = new int[n, n];
        int element = 1;

        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                matrix[row, col] = element;
                element++;
            }
        }

        //print it on the console
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