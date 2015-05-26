using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;


class ClearingCommands
{
    static void Main()
    {
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
        char[,] matrix = FillCharArray(text);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char symbol = matrix[row, col];
                if (IsCommand(symbol) == true)
                {
                    matrix = ModifyArray(matrix, row, col, symbol);
                }
            }
        }
        PrintResult(matrix);
    }
    public static char[,] FillCharArray(List<string> text)
    {
        char[,] array = new char[text.Count, text[0].Length];
        for (int row = 0; row < text.Count; row++)
        {
            for (int col = 0; col < text[0].Length; col++)
            {
                char symbol = text[row][col];
                array[row, col] = symbol;
            }
        }
        return array;
    }
    public static bool IsCommand(char symbol)
    {
        bool result = false;
        switch (symbol)
        {
            case '>':
            case '<':
            case 'v':
            case '^':
                result = true;
                break;
            default: result = false;
                break;
        }
        return result;
    }
    public static char[,] ModifyArray(char[,] array, int rowStart, int colStart, char command)
    {
        if (command == '>')
        {
            array = ModifyArrayRight(array, rowStart, colStart);
        }
        else if (command == '<')
        {
            array = ModifyArrayLeft(array, rowStart, colStart);
        }
        else if (command == 'v')
        {
            array = ModifyArrayDown(array, rowStart, colStart);
        }
        else if (command == '^')
        {
            array = ModifyArrayUp(array, rowStart, colStart);
        }
        return array;
    }
    public static char[,] ModifyArrayRight(char[,] array, int rowStart, int colStart)
    {
        for (int col = colStart; col < array.GetLength(1) - 1; col++)
        {
            char nextSymbol = array[rowStart, col + 1];
            if (IsCommand(nextSymbol) == false)
            {
                array[rowStart, col + 1] = ' ';
            }
            else
            {
                break;
            }
        }
        return array;
    }
    public static char[,] ModifyArrayLeft(char[,] array, int rowStart, int colStart)
    {
        for (int col = colStart; col >= 1; col--)
        {
            char nextSymbol = array[rowStart, col - 1];
            if (IsCommand(nextSymbol) == false)
            {
                array[rowStart, col - 1] = ' ';
            }
            else
            {
                break;
            }
        }
        return array;
    }
    public static char[,] ModifyArrayDown(char[,] array, int rowStart, int colStart)
    {
        for (int row = rowStart; row < array.GetLength(0) - 1; row++)
        {
            char nextSymbol = array[row + 1, colStart];
            if (IsCommand(nextSymbol) == false)
            {
                array[row + 1, colStart] = ' ';
            }
            else
            {
                break;
            }
        }
        return array;
    }
    public static char[,] ModifyArrayUp(char[,] array, int rowStart, int colStart)
    {
        for (int row = rowStart; row >= 1; row--)
        {
            char nextSymbol = array[row - 1, colStart];
            if (IsCommand(nextSymbol) == false)
            {
                array[row - 1, colStart] = ' ';
            }
            else
            {
                break;
            }
        }
        return array;
    }
    public static void PrintResult(char[,] array)
    {
        for (int row = 0; row < array.GetLength(0); row++)
        {
            StringBuilder line = new StringBuilder();
            for (int col = 0; col < array.GetLength(1); col++)
            {
                line.Append(array[row, col]);
            }
            string result = SecurityElement.Escape(line.ToString());
            result = "<p>" + result + "</p>";
            Console.WriteLine(result);
        }
    }
}