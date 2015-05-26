using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringMatrixRotation
{
    static void Main()
    {
        string[] command = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int degrees = int.Parse(command[1]);

        List<string> text = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            text.Add(input);
        }

        char[,] matrix = FillCharMatrix(text);
        matrix = RotateMatrix(matrix, degrees);
        PrintCharMatrix(matrix);
    }
    public static int FindLongestString(List<string> text)
    {
        int maxLen = 0;
        foreach (var entry in text)
        {
            if (entry.Length > maxLen)
            {
                maxLen = entry.Length;
            }
        }
        return maxLen;
    }
    public static char[,] FillCharMatrix(List<string> text)
    {
        char[,] matrix = new char[text.Count, FindLongestString(text)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (text[row].Length > col)
                {
                    matrix[row, col] = text[row][col];
                }
                else
                {
                    matrix[row, col] = ' ';
                }
                
            }
        }
        return matrix;
    }
    public static char[,] RotateMatrix(char[,] matrix, int degrees)
    {
        //rotate 90 degrees
        if (degrees == 90 || degrees % 360 == 90)
        {
            char[,] result = new char[matrix.GetLength(1), matrix.GetLength(0)];
            int rowResult = 0;
            int colResult = result.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char symbol = matrix[row, col];
                    result[rowResult, colResult] = symbol;
                    rowResult++;
                }
                colResult--;
                rowResult = 0;
            }
            return result;
        }
        //rotate 180 degrees
        else if (degrees == 180 || degrees % 360 == 180)
        {
            char[,] result = new char[matrix.GetLength(0), matrix.GetLength(1)];
            int rowResult = result.GetLength(0) - 1;
            int colResult = result.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char symbol = matrix[row, col];
                    result[rowResult, colResult] = symbol;
                    colResult--;
                }
                rowResult--;
                colResult = result.GetLength(1) - 1;
            }
            return result;
        }
        //rotate 270 degrees
        else if (degrees == 270 || degrees % 360 == 270)
        {
            char[,] result = new char[matrix.GetLength(1), matrix.GetLength(0)];
            int rowResult = result.GetLength(0) - 1;
            int colResult = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char symbol = matrix[row, col];
                    result[rowResult, colResult] = symbol;
                    rowResult--;
                }
                colResult++;
                rowResult = result.GetLength(0) - 1;
            }
            return result;
        }
        else
        {
            return matrix;
        }
    }
    public static void PrintCharMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            StringBuilder line = new StringBuilder();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                line.Append(matrix[row, col]);
            }
            Console.WriteLine(line.ToString());
        }
    }
}