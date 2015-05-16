using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            //get the integer value of the character
            int intValue = (int)input[i];
            //convert it to hexadecimal
            string hexValue = intValue.ToString("X");

            //assemble the result string and print it
            string result = ("\\u00" + hexValue).ToLower();
            Console.Write(result);
        }
        Console.WriteLine();
    }
}