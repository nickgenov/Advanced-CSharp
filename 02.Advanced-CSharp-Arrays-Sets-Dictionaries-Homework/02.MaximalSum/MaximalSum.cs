using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaximalSum
{
    static void Main()
    {
        //parse input
        string[] input = Console.ReadLine().Trim().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] matrix = new int[n, m];

        for (int row = 0; row < n; row++)
        {
            string[] inputRow = Console.ReadLine().Trim().Split(' ');
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = int.Parse(inputRow[col]);
            }
        }
     
        //check the max sum of a 3x3 matrix
        int[,] squareMatrixMax = new int[3,3];
        int maxSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int[,] squareMatrix = ReturnSquareMatrix(matrix, row, col);
                int currentSum = ReturnMatrixSum(squareMatrix);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    squareMatrixMax = squareMatrix;
                }
            }
        }

        //print the result
        Console.WriteLine("Sum = {0}", maxSum);
        PrintMatrix(squareMatrixMax);

    }
    public static int[,] ReturnSquareMatrix(int[,] matrix, int rowStart, int colStart) 
    {
        int[,] squareMatrix = new int[3, 3];
        for (int row = rowStart; row < rowStart + 3; row++)
        {
            for (int col = colStart; col < colStart + 3; col++)
            {
                squareMatrix[row - rowStart, col - colStart] = matrix[row, col];
            }
        }
        return squareMatrix;
    }
    public static int ReturnMatrixSum(int[,] matrix)
    {
        int sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }
        }
        return sum;
    }
    public static void PrintMatrix(int[,] matrix)
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