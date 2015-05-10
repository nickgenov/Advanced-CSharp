using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArrayOfNumbers
{
    static void Main()
    {
        //parse input
        string[] input = Console.ReadLine().Trim().Split(' ');
        double[] numbers = new double[input.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = double.Parse(input[i]);
        }

        //sort
        Array.Sort(numbers);

        //print result
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]);
            if (i < numbers.Length - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}