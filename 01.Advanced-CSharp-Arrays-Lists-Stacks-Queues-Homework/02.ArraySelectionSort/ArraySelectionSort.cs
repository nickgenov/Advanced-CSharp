using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ArraySelectionSort
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

        //selection sort algorithm
        bool swapped = false;
        do
        {
            swapped = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                double temp = 0;
                if (numbers[i] > numbers[i + 1])
                {
                    temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;
                }
            }
        } while (swapped == true);

        //print the sorted array
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