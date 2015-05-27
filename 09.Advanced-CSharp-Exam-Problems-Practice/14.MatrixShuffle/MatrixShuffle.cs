using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//UNFINISHED!!!
class MatrixShuffle
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] board = new char[size, size];

        //fill spiral pattern
        int textIndex = 0;
        int row = 0;
        int col = 0;
        int turnedCornersCount = 0;
        string direction = "right";
        int stepsMoved = 0;
        int stepsToMove = size;

        while (true)
        {
            board[row, col] = text[textIndex];
            stepsMoved++;
            string newDirection = GetDirection(direction, stepsMoved, stepsToMove);

            if (newDirection == "right")
            {
                col++;
            }
            else if (newDirection == "down")
            {
                row++;
            }
            else if (newDirection == "left")
            {
                col--;
            }
            else if (newDirection == "up")
            {
                row--;
            }

            if (direction != newDirection)
            {
                turnedCornersCount++;
                stepsMoved = 1;
            }
            if (turnedCornersCount == 3)
            {
                stepsToMove--;
                turnedCornersCount = 0;
            }
            direction = newDirection;
            textIndex++;
            if (textIndex == text.Length)
            {
                break;
            }
        }

        //assemble new text
        string extractedText = ExtractLettersOnWhiteSquares(board) + ExtractLettersOnBlackSquares(board);

        //determine the result
        if (CheckPalindrome(RemoveNonLetterChars(extractedText).ToLower()) == true)
        {
            Console.WriteLine("palindrome");
            Console.WriteLine(extractedText);
        }
        else
        {
            Console.WriteLine("NO");
            Console.WriteLine(extractedText);
        }
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
    public static string GetDirection(string direction, int stepsMoved, int stepsToMove)
    {
        string newDirection = string.Empty;
        if (direction == "right" && stepsMoved < stepsToMove)
        {
            newDirection = "right";
        }
        else if (direction == "right" && stepsMoved == stepsToMove)
        {
            newDirection = "down";
        }
        else if (direction == "down" && stepsMoved < stepsToMove)
        {
            newDirection = "down";
        }
        else if (direction == "down" && stepsMoved == stepsToMove)
        {
            newDirection = "left";
        }
        else if (direction == "left" && stepsMoved < stepsToMove)
        {
            newDirection = "left";
        }
        else if (direction == "left" && stepsMoved == stepsToMove)
        {
            newDirection = "up";
        }
        else if (direction == "up" && stepsMoved < stepsToMove)
        {
            newDirection = "up";
        }
        else if (direction == "up" && stepsMoved == stepsToMove)
        {
            newDirection = "right";
        }
        return newDirection;
    }
    public static string ExtractLettersOnWhiteSquares(char[,] board)
    {
        string result = string.Empty;
        StringBuilder buildResult = new StringBuilder();
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(0); col++)
            {
                if (row % 2 == 0 && col % 2 == 0 && board[row, col] != '\0')
                {
                    buildResult.Append(board[row, col]);
                }
                else if (row % 2 == 1 && col % 2 == 1 && board[row, col] != '\0')
                {
                    buildResult.Append(board[row, col]);
                }
            }
        }
        result = buildResult.ToString();
        return result;
    }
    public static string ExtractLettersOnBlackSquares(char[,] board)
    {
        string result = string.Empty;
        StringBuilder buildResult = new StringBuilder();
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(0); col++)
            {
                if (row % 2 == 0 && col % 2 == 1 && board[row, col] != '\0')
                {
                    buildResult.Append(board[row, col]);
                }
                else if (row % 2 == 1 && col % 2 == 0 && board[row, col] != '\0')
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
        if (reversed == text)
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