using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceInMatrix
{
    static void Main()
    {
        //parse input
        int rowCount = int.Parse(Console.ReadLine());
        int colCount = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rowCount, colCount];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] inputRow = Console.ReadLine().Trim().Split(' ');
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = inputRow[col];
            }
        }
        //check correct input parse
        //PrintMatrix(matrix);

        //check sequences of repeating elements
        int maxSequenceLength = 0;
        string maxSequenceElement = "";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int maxHorizontalCount = ReturnRowRepeatCount(matrix, row, col);
                int maxVerticalCount = ReturnColRepeatCount(matrix, row, col);
                int maxDiagonalCount = ReturnDiagonalRepeatCount(matrix, row, col);
                
                int[] counts = {maxHorizontalCount, maxVerticalCount, maxDiagonalCount};
                Array.Sort(counts);

                if (counts[2] > maxSequenceLength)
                {
                    maxSequenceLength = counts[2];
                    maxSequenceElement = matrix[row, col];
                }
            }
        }

        //print the result
        for (int i = 0; i < maxSequenceLength; i++)
        {
            Console.Write(maxSequenceElement);
            if (i < maxSequenceLength - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine();
            }
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
    public static int ReturnRowRepeatCount(string[,] matrix, int row, int colStart)
    {
        int count = 1;
        string element1 = matrix[row, colStart];
        for (int col = colStart + 1; col < matrix.GetLength(1); col++)
        {
            string element2 = matrix[row, col];
            if (element1 == element2)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
    public static int ReturnColRepeatCount(string[,] matrix, int rowStart, int col)
    {
        int count = 1;
        string element1 = matrix[rowStart, col];
        for (int row = rowStart + 1; row < matrix.GetLength(0); row++)
        {
            string element2 = matrix[row, col];
            if (element1 == element2)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
    public static int ReturnDiagonalRepeatCount(string[,] matrix, int rowStart, int colStart)
    {
        int count = 1;
        string element1 = matrix[rowStart, colStart];
        for (int row = rowStart + 1; row < matrix.GetLength(0); row++)
        {
            for (int col = colStart + 1; col < matrix.GetLength(1); col++)
            {
                if (row < matrix.GetLength(0))
                {
                    string element2 = matrix[row, col];
                    if (element1 == element2)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    row++;
                }              
            }
        }
        return count;
    }
}