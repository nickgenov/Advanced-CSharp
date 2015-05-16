using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringLength
{
    static void Main()
    {
        //parse input
        string input = Console.ReadLine();

        //initialise a StringBuilder and fill it with characters
        //up to the 20th character
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(input[i]);
            if (i == 19)
            {
                break;
            }
        }

        //if the StringBuilder holds less than 20 characters
        //fill the end with *
        if (result.Length < 20)
        {
            int starsToAdd = 20 - result.Length;
            for (int i = 0; i < starsToAdd; i++)
            {
                result.Append("*");
            }
        }

        //print the result
        string output = result.ToString();
        Console.WriteLine(output);
    }
}