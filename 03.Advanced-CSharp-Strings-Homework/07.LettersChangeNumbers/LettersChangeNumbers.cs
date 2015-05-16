using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LettersChangeNumbers
{
    static void Main()
    {
        //split the input by whitespaces and remove empty entries
        string[] input = Console.ReadLine()
            .Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        //perform the calculations
        double sum = 0;
        foreach (var word in input)
        {
            double number = firstLetterCalculations(word);
            number = lastLetterCalculations(word, number);

            sum += number;
        }

        //print the result
        Console.WriteLine("{0:F2}", sum);
    }

    public static double firstLetterCalculations(string input)
    {
        char letter = input[0];
        double number = double.Parse(input.Substring(1, input.Length - 2));
        double result = 0;

        if (char.IsLower(letter))
        {
            int alphabetPos = letter - 96;
            result = number * alphabetPos;
        }
        else
        {
            int alphabetPos = letter - 64;
            result = number / alphabetPos;
        }

        return result;
    }
    public static double lastLetterCalculations(string input, double number)
    {
        char letter = input[input.Length - 1];
        double result = 0;

        if (char.IsLower(letter))
        {
            int alphabetPos = letter - 96;
            result = number + alphabetPos;
        }
        else
        {
            int alphabetPos = letter - 64;
            result = number - alphabetPos;
        }

        return result;
    }
}