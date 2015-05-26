using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlusRemove
{
    static void Main()
    {
        List<List<char>> text = new List<List<char>>();
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            List<char> symbols = input.ToList();
            text.Add(symbols);
        }

        List<List<int>> indexesToRemove = new List<List<int>>();

        for (int row = 0; row < text.Count - 2; row++)
        {
            for (int col = 1; col < FindLongestString(text) - 1; col++)
            {
                if (text[row].Count > col &&
                    text[row + 1].Count > col - 1 &&
                    text[row + 1].Count > col &&
                    text[row + 1].Count > col + 1 &&
                    text[row + 2].Count > col)
                {
                    string a = text[row][col].ToString().ToLower();
                    string b = text[row + 1][col - 1].ToString().ToLower();
                    string c = text[row + 1][col].ToString().ToLower();
                    string d = text[row + 1][col + 1].ToString().ToLower();
                    string e = text[row + 2][col].ToString().ToLower();

                    if (a == b && b == c && c == d && d == e)
                    {
                        indexesToRemove.Add(new List<int>() { row, col });
                        indexesToRemove.Add(new List<int>() { row + 1, col - 1 });
                        indexesToRemove.Add(new List<int>() { row + 1, col });
                        indexesToRemove.Add(new List<int>() { row + 1, col + 1});
                        indexesToRemove.Add(new List<int>() { row + 2, col });
                    }
                }
            }
        }

        foreach (var list in indexesToRemove)
        {
            int row = list[0];
            int col = list[1];
            text[row][col] = ' ';
        }

        PrintText(text);
    }
    public static int FindLongestString(List<List<char>> text)
    {
        int maxLen = 0;
        foreach (var row in text)
        {
            if (row.Count > maxLen)
            {
                maxLen = row.Count;
            }
        }
        return maxLen;
    }
    public static char[,] CreateCharArray(List<List<char>> text)
    {
        int columns = FindLongestString(text);
        int rows = text.Count;
        char[,] array = new char[rows, columns];

        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                if (text[row].Count > col)
                {
                    array[row, col] = text[row][col];
                }
            }
        }
        return array;
    }
    public static void PrintText(List<List<char>> text)
    {
        foreach (var row in text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var character in row)
            {
                if (character != ' ')
                {
                    builder.Append(character);
                }
            }
            Console.WriteLine(builder.ToString());
        }
    }
    public static void PrintText(char[,] text)
    {
        for (int row = 0; row < text.GetLength(0); row++)
        {
            StringBuilder builder = new StringBuilder();
            for (int col = 0; col < text.GetLength(1); col++)
            {
                builder.Append(text[row, col]);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}