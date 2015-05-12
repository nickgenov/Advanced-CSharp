using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseNumber
{
    static void Main()
    {
        string input = Console.ReadLine();
        double reversed = GetReversedNumber(input);
        Console.WriteLine(reversed);
    }
    public static double GetReversedNumber(string input)
    {
        StringBuilder reversedStr = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedStr.Append(input[i]);
        }
        string doubleAsString = reversedStr.ToString();

        double result = double.Parse(doubleAsString);
        return result;
    }
}