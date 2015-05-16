using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        StringBuilder reversedInput = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            char symbol = input[i];
            reversedInput.Append(symbol);
        }

        string result = reversedInput.ToString();
        Console.WriteLine(result);
    }
}