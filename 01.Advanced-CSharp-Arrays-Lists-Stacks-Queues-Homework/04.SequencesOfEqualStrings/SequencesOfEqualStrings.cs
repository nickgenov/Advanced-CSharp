using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split(' ');

        for (int i = 0; i < input.Length - 1; i++)
        {
            Console.Write(input[i] + " ");
            if ((input[i] == input[i + 1]) == false)
            {
                Console.WriteLine();
            }
            if (i == input.Length - 2)
            {
                Console.Write(input[input.Length - 1]);
            }
        }

        if (input.Length == 1)
        {
            Console.WriteLine(input[0]);
        }
        Console.WriteLine();
    }
}