using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatrixShuffle2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] matrix = FillMatrix(n, text);

        //assemble the text
        string extractedText = LettersOnWhiteSquares(matrix) + LettersOnBlackSquares(matrix);

        //print the result
        if (CheckPalindrome(extractedText.ToLower()))
        {
            Console.WriteLine(string.Format("<div style='background-color:#4FE000'>{0}</div>", extractedText));
        }
        else
        {
            Console.WriteLine(string.Format("<div style='background-color:#E0000F'>{0}</div>", extractedText));
        }
    }
    public static char[,] FillMatrix(int n, string text)
    {
        int textIndex = 0;
        char[,] matrix = new char[n, n];
        int row = 0;
        int col = 0;
        string direction = "right";
        int maxRotations = n * n;

        for (int i = 1; i <= maxRotations; i++)
        {
            if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
            {
                direction = "down";
                col--;
                row++;
            }
            if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
            {
                direction = "left";
                row--;
                col--;
            }
            if (direction == "left" && (col < 0 || matrix[row, col] != 0))
            {
                direction = "up";
                col++;
                row--;
            }

            if (direction == "up" && row < 0 || matrix[row, col] != 0)
            {
                direction = "right";
                row++;
                col++;
            }

            matrix[row, col] = text[textIndex];
            textIndex++;
            if (textIndex == text.Length)
            {
                break;
            }

            if (direction == "right")
            {
                col++;
            }
            if (direction == "down")
            {
                row++;
            }
            if (direction == "left")
            {
                col--;
            }
            if (direction == "up")
            {
                row--;
            }
        }
        return matrix;
    }
    public static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            StringBuilder buildRow = new StringBuilder();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                buildRow.Append(matrix[row, col]);
            }
            Console.WriteLine(buildRow.ToString());
        }
        Console.WriteLine();
    }
    public static string LettersOnWhiteSquares(char[,] board)
    {
        string result = string.Empty;
        StringBuilder buildResult = new StringBuilder();
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == '\0')
                {
                    board[row, col] = ' ';
                }
                if (row % 2 == 0 && col % 2 == 0)
                {
                    buildResult.Append(board[row, col]);
                }
                else if (row % 2 == 1 && col % 2 == 1)
                {
                    buildResult.Append(board[row, col]);
                }
            }
        }
        result = buildResult.ToString();
        return result;
    }
    public static string LettersOnBlackSquares(char[,] board)
    {
        string result = string.Empty;
        StringBuilder buildResult = new StringBuilder();
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == '\0')
                {
                    board[row, col] = ' ';
                }
                if (row % 2 == 0 && col % 2 == 1)
                {
                    buildResult.Append(board[row, col]);
                }
                else if (row % 2 == 1 && col % 2 == 0)
                {
                    buildResult.Append(board[row, col]);
                }
            }
        }
        result = buildResult.ToString();
        return result;
    }
    public static bool CheckPalindrome(string text)
    {
        string reversed = ReverseString(text);
        reversed = RemoveNonLetterChars(reversed);

        if (reversed == RemoveNonLetterChars(text))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public static string ReverseString(string text)
    {
        StringBuilder result = new StringBuilder();
        for (int i = text.Length - 1; i >= 0; i--)
        {
            result.Append(text[i]);
        }
        return result.ToString();
    }
    public static string RemoveNonLetterChars(string text)
    {
        StringBuilder result = new StringBuilder();
        foreach (var character in text)
        {
            if (char.IsLetter(character))
            {
                result.Append(character);
            }
        }
        return result.ToString();
    }
}