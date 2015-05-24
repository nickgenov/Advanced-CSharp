using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;


class TextGravity
{
    static void Main()
    {
        //read input lines and text
        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        //fill the characters in an array
        char[,] array = FillCharArray(text, lineLength);
        //make the letters fall down
        array = FallingCharacters(array);

        //print the result
        PrintResult(array);
    }
    //methods to make things easier
    public static char[,] FillCharArray(string text, int lineLength)
    {
        int rowsCount = (int)Math.Ceiling((double)text.Length / (double)lineLength);
        char[,] array = new char[rowsCount, lineLength];
        int charPosition = 0;


        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                if (charPosition < text.Length)
                {
                    array[row, col] = text[charPosition];
                    charPosition++;
                }
                else
                {
                    array[row, col] = ' ';
                }

            }
        }
        return array;
    }   
    public static char[,] FallingCharacters(char[,] array)
    {
        for (int col = 0; col < array.GetLength(1); col++)
        {
            for (int row = array.GetLength(0) - 2; row >= 0; row--)
            {
                char symbol = array[row, col];

                int rowCheck = row;
                while (row < array.GetLength(0) - 1 && array[rowCheck + 1, col] == ' ')
                {
                    rowCheck++;
                    if (rowCheck + 1 >= array.GetLength(0))
                    {
                        break;
                    }
                }
                if (rowCheck != row)
                {
                    array[rowCheck, col] = symbol;
                    array[row, col] = ' ';
                }
            }
        }
        return array;
    }
    public static void PrintResult(char[,] array)
    {
        Console.Write("<table>");
        for (int row = 0; row < array.GetLength(0); row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < array.GetLength(1); col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(array[row, col].ToString()));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }
    public static void PrintCharArray(char[,] array)
    {
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                Console.Write("{0} ", array[row, col]);
            }
            Console.WriteLine();
        }
    }
}